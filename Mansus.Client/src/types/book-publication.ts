import type Book from "./book";
import type Language from "./language";
import type Product from "./product";
import type Publisher from "./publisher";

export default interface BookPublication extends Product {
    book: Book;
    publisher: Publisher;
    publishedAt: Date;
    language: Language;
}
