import { BookPrice } from "./book-price";
import { Category } from "./category";

export interface Book {
    id: string;
    title: string;
    description: string;
    coverImageUrl: string;
    publishedAt: Date;
    stock: number;
    price: number;
    bookPrices: BookPrice[];
    categories: Category[];
}
