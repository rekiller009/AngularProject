export interface Transaction {
    no:number,
    refNo:string,
    dateissued: any,
    netTotal:number,
    balanceDue:number
}

export const emptyTransaction = (): Transaction => ({
    no:0,
    refNo:"",
    dateissued: "",
    netTotal:0,
    balanceDue:0
});