type CheckboxProps = {
    label: string;
    value: boolean;
    width?: string;
    height?: string;
    onChange: React.ChangeEventHandler<HTMLInputElement> | undefined;
}

const Checkbox = (props: CheckboxProps) => {
    const { label, value, width, height, onChange } = props;
    return (
        <label>
            <input
                style={{ height: width, width: height }}
                type="checkbox"
                checked={value}
                onChange={onChange} />
            { label }
        </label>
    )
}

export default Checkbox;