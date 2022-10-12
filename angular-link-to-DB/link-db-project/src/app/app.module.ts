import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailsComponent } from './user/user-list/user-details/user-details.component';
import { UserEditDetailsComponent } from './user/user-list/user-edit-details/user-edit-details.component';
import { UserDeleteComponent } from './user/user-list/user-delete/user-delete.component';
import { UserAddComponent } from './user/user-add/user-add.component';
import { UserComponent } from './user/user.component';
import { HomeComponent } from './home/home.component';
import { IntroductionComponent } from './home/introduction/introduction.component';
import { ExperienceComponent } from './home/experience/experience.component';
import { ServicesOfferComponent } from './home/services-offer/services-offer.component';
import { GalleryComponent } from './home/gallery/gallery.component';
import { FeedbackComponent } from './home/feedback/feedback.component';
import { FooterComponent } from './home/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    UserDetailsComponent,
    UserEditDetailsComponent,
    UserDeleteComponent,
    UserAddComponent,
    UserComponent,
    HomeComponent,
    IntroductionComponent,
    ExperienceComponent,
    ServicesOfferComponent,
    GalleryComponent,
    FeedbackComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
