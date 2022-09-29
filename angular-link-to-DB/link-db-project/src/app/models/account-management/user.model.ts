export interface User {
    id:string;
    userName: string;
    emailAddress: string;
    createdDate: string;
    deletedDate: string;
}

export interface EditUser{
    id:string,
    userName: string,
    emailAddress: string
}

export const emptyUser = (): User => ({
    id:'',
    userName: '',
    emailAddress: '',
    createdDate: '',
    deletedDate: ''
});

export const emptyEditUser = (): EditUser => ({
    id:'',
    userName: '',
    emailAddress: ''
});

export const setUser = (id:string,userName:string,
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
