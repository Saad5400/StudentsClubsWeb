const tour = new Shepherd.Tour({
    useModalOverlay: true,
    defaultStepOptions: {
      cancelIcon: {
        enabled: true
      },
      classes: 'tour-window',
      scrollTo: { behavior: 'smooth' }
    },
  });
  
tour.addStep({
    title: 'مرحبا!',
    text: `من هذه الصفحة تقدر تبحث عن النادي المناسب لك`,
    buttons: [
        {
        action() {
            return this.next();
        },
        text: 'التالي'
        }
    ]
});

tour.addStep({    
    title: 'تصفية النتائح',
    text: `تقدر تختار التصنيفات للنادي اللي تبحث عنه`,
    attachTo: {
        element: '#filter-div',
        on: 'bottom'
      },
    scrollTo: { behavior: 'smooth', block: 'center' },
    buttons: [
        {
            action() {
                return this.back();
            },
            classes: 'shepherd-button-secondary',
            text: 'السابق'
        },
        {
            action() {
                return this.next();
            },
            text: 'التالي'
        }
    ]
});

tour.addStep({    
    title: 'الأندية',
    text: `اذا اعجبك نادي معين تقدر تضغط على اسمه لتنتقل لصفحة النادي`,
    attachTo: {
        element: '.w-card.aside-card',
        on: 'top'
      },
      scrollTo: { behavior: 'smooth', block: 'center' },
    buttons: [
        {
            action() {
                return this.back();
            },
            classes: 'shepherd-button-secondary',
            text: 'السابق'
        },
        {
            action() {
                return this.next();
            },
            text: 'انهاء'
        }
    ]
});

setTimeout(() => {
    // Initiate the tour
    if(!localStorage.getItem('shepherd-tour-clubs')) {
        tour.start();
        localStorage.setItem('shepherd-tour-clubs', 'yes');
    }
}, 1000);
