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