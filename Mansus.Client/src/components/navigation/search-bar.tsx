import { useState } from 'react'
import { FaSearch } from 'react-icons/fa';

const SearchBar = () => {
    const [searchTerm, setSearchTerm] = useState('');

    return (
        <form
            className='flex size-full'
            onSubmit={(e) => e.preventDefault()}
        >
            <input
                className='border p-2 bg-neutral-500 w-full'
                type='text'
                placeholder='Search...'
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <button className='bg-neutral-500 border w-10 justify-items-center items-center hover:cursor-pointer' type='submit'><FaSearch /></button>
        </form>
    )
}

export default SearchBar;