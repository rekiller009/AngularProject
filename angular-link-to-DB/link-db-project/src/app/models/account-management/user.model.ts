export interface User {
    id:number;
    userName: string;
    emailAddress: string;
    createdDate: string;
    deletedDate: string;
}

export const emptyUser = (): User => ({
    id:0,
    userName: '',
    emailAddress: '',
    createdDate: '',
    deletedDate: ''
});