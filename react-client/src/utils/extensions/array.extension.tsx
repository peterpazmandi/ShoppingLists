export {}

declare global {
    interface Array<T> {
        sortBy<T, V>(
            valueExtractor: (t: T) => V,
            comparator?: (a: V, b: V) => number): Array<T>;
    }
}

Array.prototype.sortBy = function<T, V> (
    valueExtractor: (t: T) => V,
    comparator?: (a: V, b: V) => number): Array<T> {

    const c = comparator ?? ((a, b) => a > b ? 1 : -1) 
    return this.sort((a, b) => c(valueExtractor(a), valueExtractor(b)))

}

// Source: https://stackoverflow.com/a/73868043/9469090
export function sortBy<T, V>(
    array: T[],
    valueExtractor: (t: T) => V,
    comparator?: (a: V, b: V) => number) {

    // note: this is a flawed default, there should be a case for equality
    // which should result in 0 for example
    const c = comparator ?? ((a, b) => a > b ? 1 : -1) 
    return array.sort((a, b) => c(valueExtractor(a), valueExtractor(b)))
}