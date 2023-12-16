import {render, fireEvent, act, waitFor} from '@testing-library/react';
import Search from './Search';

import { testData } from '../../utils/testData';
import UserItem from '../../models/UserItem';

const mockItems = testData as UserItem[];

jest.mock("../../services/api/useSearchService", () => ({
    useSearchService: () => ({
        search: (_: string) => {
            console.log("applying search", mockItems);
            return Promise.resolve(mockItems)
        } 
    })
}));

test('warns user when input is empty', async () => {
    const { queryByText, getByText } = render(<Search></Search>)
    expect(queryByText("value 1")).toBeNull()
    expect(queryByText("another 2")).toBeNull();

    act(() => {
        fireEvent.click(getByText("search!"));
    })

    expect(getByText("search input must not be empty")).toBeInTheDocument();

    expect(queryByText("value 1")).toBeNull()
    expect(queryByText("another 2")).toBeNull();
})

test('displays returned values', async () => {
    const { queryByText, getByText, getByTestId } = render(<Search></Search>)
    expect(queryByText("Kubu")).toBeNull()
    expect(queryByText("clongfu")).toBeNull();

    act(() => {
        fireEvent.change(getByTestId("search-input"), {target: {value: "foo"}});
        fireEvent.click(getByText("search!"));
    })

    expect(queryByText("search input must not be empty")).toBeNull();

    await waitFor(() => {
        expect(queryByText("No items")).toBeNull();
        expect(getByText("Kubu")).toBeInTheDocument()
    })
})

