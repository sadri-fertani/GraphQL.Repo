import { IAuthor, IPost, ISocialNet } from 'src/models/blog'

export type BlogResponse = {
    author: IAuthor;
    posts: Array<IPost>;
    socials: Array<ISocialNet>;
}

export type BlogVariables = {
    id: number;
}