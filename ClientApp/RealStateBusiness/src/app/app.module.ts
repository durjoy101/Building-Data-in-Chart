import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HighchartsChartModule } from 'highcharts-angular';

import { AppComponent } from './app.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { HighChartBuildingDataComponent } from './highChart-buildingData/highChart-buildingData.component';
import { FormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BuildingDataService } from './services/buildingData.service';

@NgModule({
  declarations: [		
    AppComponent,
    HighChartBuildingDataComponent,
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HighchartsChartModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatInputModule,
    MatFormFieldModule,
  ],
  providers: [
    BuildingDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
