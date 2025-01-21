import { Book } from "./book";

export interface Author {
    id: string;
    name: string;
    books: AuthorBooks[];
}

export interface AuthorBooks{
    id: string;
    title: string;
}


export const authors: Author[] = [
    {
        id: '1',
        name: 'J.K. Rowling',
        books: [
            { id: '101', title: 'Harry Potter and the Sorcerer\'s Stone' },
            { id: '102', title: 'Harry Potter and the Chamber of Secrets' }
        ]
    },
    {
        id: '2',
        name: 'George R.R. Martin',
        books: [
            { id: '201', title: 'A Game of Thrones' },
            { id: '202', title: 'A Clash of Kings' }
        ]
    },
    {
        id: '3',
        name: 'J.R.R. Tolkien',
        books: [
            { id: '301', title: 'The Hobbit' },
            { id: '302', title: 'The Lord of the Rings' }
        ]
    },
    {
        id: '4',
        name: 'Agatha Christie',
        books: [
            { id: '401', title: 'Murder on the Orient Express' },
            { id: '402', title: 'And Then There Were None' }
        ]
    }
];