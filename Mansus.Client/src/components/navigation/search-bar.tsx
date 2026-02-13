import { useState } from 'react'
import "./search-bar.css";

const SearchBar = () => {
    const [searchTerm, setSearchTerm] = useState('');

    return (
        <form
            className='SearchForm'
            onSubmit={(e) => e.preventDefault()}
        >
            <input
                className='SearchInput'
                type='text'
                placeholder='Search...'
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <button className='SearchButton' type='submit'>Search</button>
        </form>
    )
}

export default SearchBar;