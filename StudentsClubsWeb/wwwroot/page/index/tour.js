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
    text: `هلا فيك في موقع الأندية الطلابية Clubs Space اللي بيساعدك توصل للأندية اللي تناسبك، او تسجل ناديك معانا وتعرضه للجميع`,
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
    title: 'المميزة',
    text: `هنا بتحصل اهم المقالات والأندية`,
    attachTo: {
        element: '#featured-div',
      },
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
    title: 'التنقل',
    text: `تقدر تتنقل بين الصفحات من خلال الأزرار اللي بالأسفل`,
    attachTo: {
        element: '.customNav',
        on: 'top'
      },
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
    title: 'ابدأ البحث',
    text: `تقدر تبدأ بالبحث عن الأندية من خلال زر تصفح الأندية`,
    scrollTo: { behavior: 'smooth', block: 'center' },
    attachTo: {
        element: '#browse-clubs-btn',
        on: 'top'
      },
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
    if(!localStorage.getItem('shepherd-tour-index')) {
        tour.start();
        localStorage.setItem('shepherd-tour-index', 'yes');
    }
}, 1000);
