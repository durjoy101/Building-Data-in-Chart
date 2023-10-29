import { ReadingDTO } from "./ReadingDTO";

export class ResponseDTO {
    constructor() {
      this.Readings = [];
      this.Timestamps = [];
    }
    Readings: ReadingDTO[] ;
    Timestamps: string[] ;
  }