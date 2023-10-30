import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts/highstock';
import { BuildingDataService } from '../services/buildingData.service';
import { ReadingDTO } from '../models/ReadingDTO';
import { Building } from '../models/Building';
import { DataField } from '../models/DataField';
import { Object } from '../models/Object';

@Component({
  selector: 'app-highChart-buildingData',
  templateUrl: './highChart-buildingData.component.html',
  styleUrls: ['./highChart-buildingData.component.css']
})
export class HighChartBuildingDataComponent implements OnInit {

  chartOptions: any;
  highcharts: typeof Highcharts = Highcharts;

  selectedBuilding: string | null = ''; 
  selectedObject: string | null = '';
  selectedDataField: string | null = '';
  selectedDateRange: string | null = '';
  selectedStartDate: string | null = '';
  selectedEndDate: string | null = '';

  isLoading: boolean = false; 

  readingData : ReadingDTO[] = []  ;
  buildings : Building[] = []  ;
  objects : Object[] = []  ;
  dataFields : DataField[] = []  ;


  constructor(private buildingDataService: BuildingDataService) { }

  ngOnInit() {
    this.getBuildings();
    this.getObjects();
    this.getDataFields();
    //this.btnsearch();
  }

  lineChart(){

    this.chartOptions = {
      chart: {
        type: 'line',
      },
      title: {
        text: 'Reading Data',
      },
      accessibility: {
        enabled: false
      },
      xAxis: {
        title: {
          text: 'Timestamp',
        },
        categories: this.readingData.map(function (item) {
          return [item.timestamp];
        }),
      },
      yAxis: {
        title: {
          text: 'Value',
        },
      },
      series: [
        {
          data: this.readingData.map(function (item) {
            return [item.timestamp, item.value];
          }),
        },
      ],
      plotOptions: {
          series: {
            turboThreshold: 100000,
            boostThreshold: 1
        } 
      },
    }
  }


  btnsearch() {
    this.isLoading = true;

    const buildingId: number | undefined = this.selectedBuilding ? +this.selectedBuilding : undefined;
    const objectId: number | undefined = this.selectedObject ? +this.selectedObject : undefined;
    const dataFieldId: number | undefined = this.selectedDataField ? +this.selectedDataField : undefined;

    const defaultStartDate = new Date("2023-10-27 08:27:00.000");
    const defaultEndDate = new Date("2023-10-27 09:39:40.000");
    
    const startDate: Date | undefined = this.selectedStartDate
      ? new Date(this.selectedStartDate)
      : defaultStartDate;
    
    const endDate: Date | undefined = this.selectedEndDate
      ? new Date(this.selectedEndDate)
      : defaultEndDate;

    this.buildingDataService.btnsearch(this.selectedBuilding!,this.selectedObject!,this.selectedDataField!,startDate,endDate).subscribe((data) => {

      this.readingData = data;

      this.lineChart();

      this.isLoading = false;
    });

  }

  getDataFields(){
    this.buildingDataService.getDataFields().subscribe((data) => {
      this.dataFields = data;
    });
  }

  getObjects(){
    this.buildingDataService.getObjects().subscribe((data) => {
      this.objects = data;
    });
  }

  getBuildings(){
    this.buildingDataService.getBuildings().subscribe((data) => {
      this.buildings = data;
    });
  }

}
