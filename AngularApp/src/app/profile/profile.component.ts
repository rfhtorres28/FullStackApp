import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common'; // these provides ngStyle, ngIf, and nfor directives

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent {
   
  public isContextMenuVisible: boolean = false;

  public contextMenuPosition = { x: 0, y: 0 };


  
  showContextMenu(event: MouseEvent): void {
    event.preventDefault();

    this.isContextMenuVisible = true;
    this.contextMenuPosition = {x: event.pageX, y: event.pageY}
    
  }

  @HostListener('document:click')
  onDocumentClick(): void {
      this.isContextMenuVisible = false;
  }

  optionClicked(option: string): void {
    console.log(`${option} clicked`);
    this.isContextMenuVisible = false;
  }

}
