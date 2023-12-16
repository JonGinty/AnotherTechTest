import './ItemGrid.css'

export type ItemGridProps<T> = {
    items: T[],
    idProp?: string;
}

/** basic component to render a list of any item */
export default function ItemGrid<T>({items, idProp}: ItemGridProps<T>) {
    if (!items?.length) return <>No items to display.</>
    const firstItem = items[0];
    if (typeof(firstItem) !== "object") return <>{items.join(",")}</> // TODO: consider erroring?
    const cols = Object.keys(items[0] as object); // list all of the column names

    // make a column header for each property and build a thead
    const headers = cols.map(col => <th key={"header" + col}>{col}</th>);
    const thead = <thead><tr>{headers}</tr></thead>

    // iterate over every item and create a row for each one before wrapping in a tbody
    const tbody = <tbody>{items.map(item => {
        var itemRecord = (item as object) as Record<string, any>;
        var id = itemRecord[idProp ?? "id"];
        var cells = cols.map(col => <td key={id + col}>{itemRecord[col]}</td>)
        return <tr key={id}>{cells}</tr>
    })}</tbody>

    return <table>{thead}{tbody}</table>
}