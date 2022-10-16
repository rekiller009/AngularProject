export interface Transaction {
    no:number,
    refNo:string,
    dateIssued: any,
    netTotal:number,
    balanceDue:number
}

export const emptyTransaction = (): Transaction => ({
    no:0,
    refNo:"",
    dateIssued: "",
    netTotal:0,
    balanceDue:0
});