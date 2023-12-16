import {render, screen} from '@testing-library/react';
import ItemGrid from './ItemGrid';

test('renders correct number of headers', () => {
    const items = [{
        foo: 'value 1',
        bar: 'value 2'
    }]

    render(<ItemGrid items={items} idProp='foo' />);

    const foo = screen.getByText("foo");
    expect(foo).toBeInTheDocument();
    const bar = screen.getByText("bar");
    expect(bar).toBeInTheDocument();
})

test('renders correct number of rows', () => {
    const items = [{
        foo: 'value 1',
        bar: 'value 2'
    },
    {
        foo: 'another 1',
        bar: 'another 2'
    }]

    render(<ItemGrid items={items} idProp='foo' />);

    const val1 = screen.getByText("value 1");
    expect(val1).toBeInTheDocument();
    const val2 = screen.getByText("value 2");
    expect(val2).toBeInTheDocument();

    const a1 = screen.getByText("another 1");
    expect(a1).toBeInTheDocument();
    const a2 = screen.getByText("another 2");
    expect(a2).toBeInTheDocument();
})

