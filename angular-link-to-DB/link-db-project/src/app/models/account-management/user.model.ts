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

export const setUser = (id:number,userName:string,
                        emailAddress:string,
                        createdDate:string,
                        deletedDate:string
                        ): User => ({
        id:id,
        userName:userName,
        emailAddress:emailAddress,
        createdDate:createdDate,
        deletedDate:deletedDate
});