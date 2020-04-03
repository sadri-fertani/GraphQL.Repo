export interface IAuthor {
    id: number,
    name: string,
    bio: string,
    imgUrl: string,
    profileUrl: string
}

export interface IComment {
    id: number,
    url: string,
    description: string,
    count: number
}

export interface IPost {
    id: number,
    title: string,
    description: string,
    date: Date,
    url: string,
    author: IAuthor,
    categories: Array<ICategorie>,
    rating: IRating,
    comments: Array<IComment>
}

export interface ICategorie {
    id: number,
    name: string,
}

export interface IRating {
    id: number,
    percent: number,
    count: number
}

export interface ISocialNet {
    id: number,
    type: SNType,
    nickName: string,
    url: string,
    author: IAuthor
}

export enum SNType {
    INSTAGRAM = "INSTAGRAM",
    TWITTER = "TWITTER"
}