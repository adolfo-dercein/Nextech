import { ItemDTO } from "./item-dto";

export interface ItemResponse
{
    pageNumber: number;
    pageSize: number;
    total: number;
    items: ItemDTO[];
}