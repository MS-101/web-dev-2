export default interface PagedResponse<T> {
    items: T[];
    curPage: number;
    totalPages: number;
}
