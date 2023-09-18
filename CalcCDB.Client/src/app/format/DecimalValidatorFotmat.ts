import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appDecimalValidator]'
})
export class DecimalValidatorDirective {
  constructor(private el: ElementRef) {}

  @HostListener('input', ['$event'])
  onInput(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const inputValue = inputElement.value;

    // Use uma expressão regular para verificar se o valor é um decimal com duas casas
    if (!/^\d+(\.\d{0,2})?$/.test(inputValue)) {
      inputElement.value = inputValue.slice(0, -1); // Remove o último caractere inválido
    }
  }
}