import type Author from "./author";

export default interface Book {
    id: number;
    name: string;
    description: string;
    bookCategory: string;
    authors: Author[];
}
