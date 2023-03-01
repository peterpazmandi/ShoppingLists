type CheckboxProps = {
    label: string;
    value: boolean;
    onChange: React.ChangeEventHandler<HTMLInputElement> | undefined;
}

const Checkbox = (props: CheckboxProps) => {
    const { label, value, onChange } = props;
    return (
        <label>
            <input
                type="checkbox"
                checked={value}
                onChange={onChange} />
            { label }
        </label>
    )
}

export default Checkbox;