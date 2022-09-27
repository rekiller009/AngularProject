export interface User {
    Id:number;
    UserName: string;
    EmailAddress: string;
    CreatedDate: string;
}

export interface UserList {
    status:string;
    message:string;
    result: User[];
}