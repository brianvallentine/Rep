using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class JVBKINCL_CVP_PRODUTOS_RUNOFF : VarBasis
    {
        /*"  03  CVP-0002                     PIC S9(004) COMP-5 VALUE 0002*/
        public IntBasis CVP_0002 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0002);
        /*"  03  CVP-0901                     PIC S9(004) COMP-5 VALUE 0901*/
        public IntBasis CVP_0901 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0901);
        /*"  03  CVP-0902                     PIC S9(004) COMP-5 VALUE 0902*/
        public IntBasis CVP_0902 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0902);
        /*"  03  CVP-0903                     PIC S9(004) COMP-5 VALUE 0903*/
        public IntBasis CVP_0903 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0903);
        /*"  03  CVP-0904                     PIC S9(004) COMP-5 VALUE 0904*/
        public IntBasis CVP_0904 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0904);
        /*"  03  CVP-0905                     PIC S9(004) COMP-5 VALUE 0905*/
        public IntBasis CVP_0905 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0905);
        /*"  03  CVP-0906                     PIC S9(004) COMP-5 VALUE 0906*/
        public IntBasis CVP_0906 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0906);
        /*"  03  CVP-0907                     PIC S9(004) COMP-5 VALUE 0907*/
        public IntBasis CVP_0907 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0907);
        /*"  03  CVP-0908                     PIC S9(004) COMP-5 VALUE 0908*/
        public IntBasis CVP_0908 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0908);
        /*"  03  CVP-0909                     PIC S9(004) COMP-5 VALUE 0909*/
        public IntBasis CVP_0909 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0909);
        /*"  03  CVP-0910                     PIC S9(004) COMP-5 VALUE 0910*/
        public IntBasis CVP_0910 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0910);
        /*"  03  CVP-0911                     PIC S9(004) COMP-5 VALUE 0911*/
        public IntBasis CVP_0911 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0911);
        /*"  03  CVP-0912                     PIC S9(004) COMP-5 VALUE 0912*/
        public IntBasis CVP_0912 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0912);
        /*"  03  CVP-0913                     PIC S9(004) COMP-5 VALUE 0913*/
        public IntBasis CVP_0913 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0913);
        /*"  03  CVP-0914                     PIC S9(004) COMP-5 VALUE 0914*/
        public IntBasis CVP_0914 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0914);
        /*"  03  CVP-0915                     PIC S9(004) COMP-5 VALUE 0915*/
        public IntBasis CVP_0915 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0915);
        /*"  03  CVP-0916                     PIC S9(004) COMP-5 VALUE 0916*/
        public IntBasis CVP_0916 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0916);
        /*"  03  CVP-0917                     PIC S9(004) COMP-5 VALUE 0917*/
        public IntBasis CVP_0917 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 0917);
        /*"  03  CVP-5848                     PIC S9(004) COMP-5 VALUE 5848*/
        public IntBasis CVP_5848 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5848);
        /*"  03  CVP-3701                     PIC S9(004) COMP-5 VALUE 3701*/
        public IntBasis CVP_3701 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3701);
        /*"  03  CVP-3702                     PIC S9(004) COMP-5 VALUE 3702*/
        public IntBasis CVP_3702 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3702);
        /*"  03  CVP-3703                     PIC S9(004) COMP-5 VALUE 3703*/
        public IntBasis CVP_3703 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3703);
        /*"  03  CVP-3704                     PIC S9(004) COMP-5 VALUE 3704*/
        public IntBasis CVP_3704 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3704);
        /*"  03  CVP-3705                     PIC S9(004) COMP-5 VALUE 3705*/
        public IntBasis CVP_3705 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3705);
        /*"  03  CVP-3706                     PIC S9(004) COMP-5 VALUE 3706*/
        public IntBasis CVP_3706 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3706);
        /*"  03  CVP-3707                     PIC S9(004) COMP-5 VALUE 3707*/
        public IntBasis CVP_3707 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3707);
        /*"  03  CVP-3708                     PIC S9(004) COMP-5 VALUE 3708*/
        public IntBasis CVP_3708 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3708);
        /*"  03  CVP-3709                     PIC S9(004) COMP-5 VALUE 3709*/
        public IntBasis CVP_3709 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3709);
        /*"  03  CVP-3710                     PIC S9(004) COMP-5 VALUE 3710*/
        public IntBasis CVP_3710 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3710);
        /*"  03  CVP-3711                     PIC S9(004) COMP-5 VALUE 3711*/
        public IntBasis CVP_3711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3711);
        /*"  03  CVP-3712                     PIC S9(004) COMP-5 VALUE 3712*/
        public IntBasis CVP_3712 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3712);
        /*"  03  CVP-3713                     PIC S9(004) COMP-5 VALUE 3713*/
        public IntBasis CVP_3713 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3713);
        /*"  03  CVP-3714                     PIC S9(004) COMP-5 VALUE 3714*/
        public IntBasis CVP_3714 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3714);
        /*"  03  CVP-3715                     PIC S9(004) COMP-5 VALUE 3715*/
        public IntBasis CVP_3715 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3715);
        /*"  03  CVP-3716                     PIC S9(004) COMP-5 VALUE 3716*/
        public IntBasis CVP_3716 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3716);
        /*"  03  CVP-5501                     PIC S9(004) COMP-5 VALUE 5501*/
        public IntBasis CVP_5501 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5501);
        /*"  03  CVP-5502                     PIC S9(004) COMP-5 VALUE 5502*/
        public IntBasis CVP_5502 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5502);
        /*"  03  CVP-5503                     PIC S9(004) COMP-5 VALUE 5503*/
        public IntBasis CVP_5503 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5503);
        /*"  03  CVP-5504                     PIC S9(004) COMP-5 VALUE 5504*/
        public IntBasis CVP_5504 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5504);
        /*"  03  CVP-5505                     PIC S9(004) COMP-5 VALUE 5505*/
        public IntBasis CVP_5505 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5505);
        /*"  03  CVP-5506                     PIC S9(004) COMP-5 VALUE 5506*/
        public IntBasis CVP_5506 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5506);
        /*"  03  CVP-5507                     PIC S9(004) COMP-5 VALUE 5507*/
        public IntBasis CVP_5507 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5507);
        /*"  03  CVP-5508                     PIC S9(004) COMP-5 VALUE 5508*/
        public IntBasis CVP_5508 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5508);
        /*"  03  CVP-5509                     PIC S9(004) COMP-5 VALUE 5509*/
        public IntBasis CVP_5509 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5509);
        /*"  03  CVP-5510                     PIC S9(004) COMP-5 VALUE 5510*/
        public IntBasis CVP_5510 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5510);
        /*"  03  CVP-5511                     PIC S9(004) COMP-5 VALUE 5511*/
        public IntBasis CVP_5511 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5511);
        /*"  03  CVP-5512                     PIC S9(004) COMP-5 VALUE 5512*/
        public IntBasis CVP_5512 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5512);
        /*"  03  CVP-5513                     PIC S9(004) COMP-5 VALUE 5513*/
        public IntBasis CVP_5513 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5513);
        /*"  03  CVP-5514                     PIC S9(004) COMP-5 VALUE 5514*/
        public IntBasis CVP_5514 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5514);
        /*"  03  CVP-5515                     PIC S9(004) COMP-5 VALUE 5515*/
        public IntBasis CVP_5515 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5515);
        /*"  03  CVP-5516                     PIC S9(004) COMP-5 VALUE 5516*/
        public IntBasis CVP_5516 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5516);
        /*"  03  CVP-5517                     PIC S9(004) COMP-5 VALUE 5517*/
        public IntBasis CVP_5517 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5517);
        /*"  03  CVP-5518                     PIC S9(004) COMP-5 VALUE 5518*/
        public IntBasis CVP_5518 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5518);
        /*"  03  CVP-5519                     PIC S9(004) COMP-5 VALUE 5519*/
        public IntBasis CVP_5519 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5519);
        /*"  03  CVP-5520                     PIC S9(004) COMP-5 VALUE 5520*/
        public IntBasis CVP_5520 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5520);
        /*"  03  CVP-5521                     PIC S9(004) COMP-5 VALUE 5521*/
        public IntBasis CVP_5521 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5521);
        /*"  03  CVP-5522                     PIC S9(004) COMP-5 VALUE 5522*/
        public IntBasis CVP_5522 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5522);
        /*"  03  CVP-5523                     PIC S9(004) COMP-5 VALUE 5523*/
        public IntBasis CVP_5523 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5523);
        /*"  03  CVP-5524                     PIC S9(004) COMP-5 VALUE 5524*/
        public IntBasis CVP_5524 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5524);
        /*"  03  CVP-5525                     PIC S9(004) COMP-5 VALUE 5525*/
        public IntBasis CVP_5525 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5525);
        /*"  03  CVP-5526                     PIC S9(004) COMP-5 VALUE 5526*/
        public IntBasis CVP_5526 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5526);
        /*"  03  CVP-5527                     PIC S9(004) COMP-5 VALUE 5527*/
        public IntBasis CVP_5527 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5527);
        /*"  03  CVP-5528                     PIC S9(004) COMP-5 VALUE 5528*/
        public IntBasis CVP_5528 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5528);
        /*"  03  CVP-5529                     PIC S9(004) COMP-5 VALUE 5529*/
        public IntBasis CVP_5529 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5529);
        /*"  03  CVP-5530                     PIC S9(004) COMP-5 VALUE 5530*/
        public IntBasis CVP_5530 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5530);
        /*"  03  CVP-5531                     PIC S9(004) COMP-5 VALUE 5531*/
        public IntBasis CVP_5531 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5531);
        /*"  03  CVP-5532                     PIC S9(004) COMP-5 VALUE 5532*/
        public IntBasis CVP_5532 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5532);
        /*"  03  CVP-5533                     PIC S9(004) COMP-5 VALUE 5533*/
        public IntBasis CVP_5533 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5533);
        /*"  03  CVP-5534                     PIC S9(004) COMP-5 VALUE 5534*/
        public IntBasis CVP_5534 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5534);
        /*"  03  CVP-5535                     PIC S9(004) COMP-5 VALUE 5535*/
        public IntBasis CVP_5535 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5535);
        /*"  03  CVP-5536                     PIC S9(004) COMP-5 VALUE 5536*/
        public IntBasis CVP_5536 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5536);
        /*"  03  CVP-5537                     PIC S9(004) COMP-5 VALUE 5537*/
        public IntBasis CVP_5537 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5537);
        /*"  03  CVP-5538                     PIC S9(004) COMP-5 VALUE 5538*/
        public IntBasis CVP_5538 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5538);
        /*"  03  CVP-5539                     PIC S9(004) COMP-5 VALUE 5539*/
        public IntBasis CVP_5539 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5539);
        /*"  03  CVP-5540                     PIC S9(004) COMP-5 VALUE 5540*/
        public IntBasis CVP_5540 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5540);
        /*"  03  CVP-5541                     PIC S9(004) COMP-5 VALUE 5541*/
        public IntBasis CVP_5541 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5541);
        /*"  03  CVP-5542                     PIC S9(004) COMP-5 VALUE 5542*/
        public IntBasis CVP_5542 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5542);
        /*"  03  CVP-5543                     PIC S9(004) COMP-5 VALUE 5543*/
        public IntBasis CVP_5543 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5543);
        /*"  03  CVP-5544                     PIC S9(004) COMP-5 VALUE 5544*/
        public IntBasis CVP_5544 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5544);
        /*"  03  CVP-5545                     PIC S9(004) COMP-5 VALUE 5545*/
        public IntBasis CVP_5545 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5545);
        /*"  03  CVP-5546                     PIC S9(004) COMP-5 VALUE 5546*/
        public IntBasis CVP_5546 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5546);
        /*"  03  CVP-5547                     PIC S9(004) COMP-5 VALUE 5547*/
        public IntBasis CVP_5547 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5547);
        /*"  03  CVP-5548                     PIC S9(004) COMP-5 VALUE 5548*/
        public IntBasis CVP_5548 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5548);
        /*"  03  CVP-5549                     PIC S9(004) COMP-5 VALUE 5549*/
        public IntBasis CVP_5549 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5549);
        /*"  03  CVP-5550                     PIC S9(004) COMP-5 VALUE 5550*/
        public IntBasis CVP_5550 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5550);
        /*"  03  CVP-5551                     PIC S9(004) COMP-5 VALUE 5551*/
        public IntBasis CVP_5551 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5551);
        /*"  03  CVP-5552                     PIC S9(004) COMP-5 VALUE 5552*/
        public IntBasis CVP_5552 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5552);
        /*"  03  CVP-5553                     PIC S9(004) COMP-5 VALUE 5553*/
        public IntBasis CVP_5553 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5553);
        /*"  03  CVP-5554                     PIC S9(004) COMP-5 VALUE 5554*/
        public IntBasis CVP_5554 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5554);
        /*"  03  CVP-5555                     PIC S9(004) COMP-5 VALUE 5555*/
        public IntBasis CVP_5555 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5555);
        /*"  03  CVP-5556                     PIC S9(004) COMP-5 VALUE 5556*/
        public IntBasis CVP_5556 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5556);
        /*"  03  CVP-5557                     PIC S9(004) COMP-5 VALUE 5557*/
        public IntBasis CVP_5557 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5557);
        /*"  03  CVP-5558                     PIC S9(004) COMP-5 VALUE 5558*/
        public IntBasis CVP_5558 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5558);
        /*"  03  CVP-5559                     PIC S9(004) COMP-5 VALUE 5559*/
        public IntBasis CVP_5559 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5559);
        /*"  03  CVP-5560                     PIC S9(004) COMP-5 VALUE 5560*/
        public IntBasis CVP_5560 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5560);
        /*"  03  CVP-5561                     PIC S9(004) COMP-5 VALUE 5561*/
        public IntBasis CVP_5561 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5561);
        /*"  03  CVP-5562                     PIC S9(004) COMP-5 VALUE 5562*/
        public IntBasis CVP_5562 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5562);
        /*"  03  CVP-5563                     PIC S9(004) COMP-5 VALUE 5563*/
        public IntBasis CVP_5563 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5563);
        /*"  03  CVP-5564                     PIC S9(004) COMP-5 VALUE 5564*/
        public IntBasis CVP_5564 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5564);
        /*"  03  CVP-5565                     PIC S9(004) COMP-5 VALUE 5565*/
        public IntBasis CVP_5565 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5565);
        /*"  03  CVP-5566                     PIC S9(004) COMP-5 VALUE 5566*/
        public IntBasis CVP_5566 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5566);
        /*"  03  CVP-5567                     PIC S9(004) COMP-5 VALUE 5567*/
        public IntBasis CVP_5567 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5567);
        /*"  03  CVP-5568                     PIC S9(004) COMP-5 VALUE 5568*/
        public IntBasis CVP_5568 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5568);
        /*"  03  CVP-5569                     PIC S9(004) COMP-5 VALUE 5569*/
        public IntBasis CVP_5569 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5569);
        /*"  03  CVP-5570                     PIC S9(004) COMP-5 VALUE 5570*/
        public IntBasis CVP_5570 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5570);
        /*"  03  CVP-5571                     PIC S9(004) COMP-5 VALUE 5571*/
        public IntBasis CVP_5571 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5571);
        /*"  03  CVP-5572                     PIC S9(004) COMP-5 VALUE 5572*/
        public IntBasis CVP_5572 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5572);
        /*"  03  CVP-5573                     PIC S9(004) COMP-5 VALUE 5573*/
        public IntBasis CVP_5573 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5573);
        /*"  03  CVP-5574                     PIC S9(004) COMP-5 VALUE 5574*/
        public IntBasis CVP_5574 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5574);
        /*"  03  CVP-5575                     PIC S9(004) COMP-5 VALUE 5575*/
        public IntBasis CVP_5575 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5575);
        /*"  03  CVP-5576                     PIC S9(004) COMP-5 VALUE 5576*/
        public IntBasis CVP_5576 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5576);
        /*"  03  CVP-5577                     PIC S9(004) COMP-5 VALUE 5577*/
        public IntBasis CVP_5577 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5577);
        /*"  03  CVP-5578                     PIC S9(004) COMP-5 VALUE 5578*/
        public IntBasis CVP_5578 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5578);
        /*"  03  CVP-5579                     PIC S9(004) COMP-5 VALUE 5579*/
        public IntBasis CVP_5579 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5579);
        /*"  03  CVP-5580                     PIC S9(004) COMP-5 VALUE 5580*/
        public IntBasis CVP_5580 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5580);
        /*"  03  CVP-5581                     PIC S9(004) COMP-5 VALUE 5581*/
        public IntBasis CVP_5581 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5581);
        /*"  03  CVP-5582                     PIC S9(004) COMP-5 VALUE 5582*/
        public IntBasis CVP_5582 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5582);
        /*"  03  CVP-5583                     PIC S9(004) COMP-5 VALUE 5583*/
        public IntBasis CVP_5583 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5583);
        /*"  03  CVP-5584                     PIC S9(004) COMP-5 VALUE 5584*/
        public IntBasis CVP_5584 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5584);
        /*"  03  CVP-5585                     PIC S9(004) COMP-5 VALUE 5585*/
        public IntBasis CVP_5585 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5585);
        /*"  03  CVP-5586                     PIC S9(004) COMP-5 VALUE 5586*/
        public IntBasis CVP_5586 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5586);
        /*"  03  CVP-5587                     PIC S9(004) COMP-5 VALUE 5587*/
        public IntBasis CVP_5587 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5587);
        /*"  03  CVP-5588                     PIC S9(004) COMP-5 VALUE 5588*/
        public IntBasis CVP_5588 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5588);
        /*"  03  CVP-5589                     PIC S9(004) COMP-5 VALUE 5589*/
        public IntBasis CVP_5589 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5589);
        /*"  03  CVP-5590                     PIC S9(004) COMP-5 VALUE 5590*/
        public IntBasis CVP_5590 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5590);
        /*"  03  CVP-5591                     PIC S9(004) COMP-5 VALUE 5591*/
        public IntBasis CVP_5591 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5591);
        /*"  03  CVP-5592                     PIC S9(004) COMP-5 VALUE 5592*/
        public IntBasis CVP_5592 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5592);
        /*"  03  CVP-5597                     PIC S9(004) COMP-5 VALUE 5597*/
        public IntBasis CVP_5597 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5597);
        /*"  03  CVP-5598                     PIC S9(004) COMP-5 VALUE 5598*/
        public IntBasis CVP_5598 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5598);
        /*"  03  CVP-5601                     PIC S9(004) COMP-5 VALUE 5601*/
        public IntBasis CVP_5601 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5601);
        /*"  03  CVP-5602                     PIC S9(004) COMP-5 VALUE 5602*/
        public IntBasis CVP_5602 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5602);
        /*"  03  CVP-5603                     PIC S9(004) COMP-5 VALUE 5603*/
        public IntBasis CVP_5603 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5603);
        /*"  03  CVP-5604                     PIC S9(004) COMP-5 VALUE 5604*/
        public IntBasis CVP_5604 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5604);
        /*"  03  CVP-5605                     PIC S9(004) COMP-5 VALUE 5605*/
        public IntBasis CVP_5605 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5605);
        /*"  03  CVP-5606                     PIC S9(004) COMP-5 VALUE 5606*/
        public IntBasis CVP_5606 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5606);
        /*"  03  CVP-5607                     PIC S9(004) COMP-5 VALUE 5607*/
        public IntBasis CVP_5607 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5607);
        /*"  03  CVP-5608                     PIC S9(004) COMP-5 VALUE 5608*/
        public IntBasis CVP_5608 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5608);
        /*"  03  CVP-5609                     PIC S9(004) COMP-5 VALUE 5609*/
        public IntBasis CVP_5609 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5609);
        /*"  03  CVP-5610                     PIC S9(004) COMP-5 VALUE 5610*/
        public IntBasis CVP_5610 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5610);
        /*"  03  CVP-5611                     PIC S9(004) COMP-5 VALUE 5611*/
        public IntBasis CVP_5611 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5611);
        /*"  03  CVP-5612                     PIC S9(004) COMP-5 VALUE 5612*/
        public IntBasis CVP_5612 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5612);
        /*"  03  CVP-5613                     PIC S9(004) COMP-5 VALUE 5613*/
        public IntBasis CVP_5613 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5613);
        /*"  03  CVP-5614                     PIC S9(004) COMP-5 VALUE 5614*/
        public IntBasis CVP_5614 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5614);
        /*"  03  CVP-5615                     PIC S9(004) COMP-5 VALUE 5615*/
        public IntBasis CVP_5615 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5615);
        /*"  03  CVP-5616                     PIC S9(004) COMP-5 VALUE 5616*/
        public IntBasis CVP_5616 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5616);
        /*"  03  CVP-5617                     PIC S9(004) COMP-5 VALUE 5617*/
        public IntBasis CVP_5617 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5617);
        /*"  03  CVP-5618                     PIC S9(004) COMP-5 VALUE 5618*/
        public IntBasis CVP_5618 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5618);
        /*"  03  CVP-5619                     PIC S9(004) COMP-5 VALUE 5619*/
        public IntBasis CVP_5619 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5619);
        /*"  03  CVP-5620                     PIC S9(004) COMP-5 VALUE 5620*/
        public IntBasis CVP_5620 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5620);
        /*"  03  CVP-5621                     PIC S9(004) COMP-5 VALUE 5621*/
        public IntBasis CVP_5621 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5621);
        /*"  03  CVP-5622                     PIC S9(004) COMP-5 VALUE 5622*/
        public IntBasis CVP_5622 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5622);
        /*"  03  CVP-5623                     PIC S9(004) COMP-5 VALUE 5623*/
        public IntBasis CVP_5623 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5623);
        /*"  03  CVP-5624                     PIC S9(004) COMP-5 VALUE 5624*/
        public IntBasis CVP_5624 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5624);
        /*"  03  CVP-5625                     PIC S9(004) COMP-5 VALUE 5625*/
        public IntBasis CVP_5625 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5625);
        /*"  03  CVP-5626                     PIC S9(004) COMP-5 VALUE 5626*/
        public IntBasis CVP_5626 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5626);
        /*"  03  CVP-5627                     PIC S9(004) COMP-5 VALUE 5627*/
        public IntBasis CVP_5627 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5627);
        /*"  03  CVP-5628                     PIC S9(004) COMP-5 VALUE 5628*/
        public IntBasis CVP_5628 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5628);
        /*"  03  CVP-5629                     PIC S9(004) COMP-5 VALUE 5629*/
        public IntBasis CVP_5629 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5629);
        /*"  03  CVP-5630                     PIC S9(004) COMP-5 VALUE 5630*/
        public IntBasis CVP_5630 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5630);
        /*"  03  CVP-5631                     PIC S9(004) COMP-5 VALUE 5631*/
        public IntBasis CVP_5631 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5631);
        /*"  03  CVP-5632                     PIC S9(004) COMP-5 VALUE 5632*/
        public IntBasis CVP_5632 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5632);
        /*"  03  CVP-5633                     PIC S9(004) COMP-5 VALUE 5633*/
        public IntBasis CVP_5633 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5633);
        /*"  03  CVP-5634                     PIC S9(004) COMP-5 VALUE 5634*/
        public IntBasis CVP_5634 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5634);
        /*"  03  CVP-5635                     PIC S9(004) COMP-5 VALUE 5635*/
        public IntBasis CVP_5635 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5635);
        /*"  03  CVP-5636                     PIC S9(004) COMP-5 VALUE 5636*/
        public IntBasis CVP_5636 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5636);
        /*"  03  CVP-5637                     PIC S9(004) COMP-5 VALUE 5637*/
        public IntBasis CVP_5637 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5637);
        /*"  03  CVP-5638                     PIC S9(004) COMP-5 VALUE 5638*/
        public IntBasis CVP_5638 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5638);
        /*"  03  CVP-5699                     PIC S9(004) COMP-5 VALUE 5699*/
        public IntBasis CVP_5699 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5699);
        /*"  03  CVP-5801                     PIC S9(004) COMP-5 VALUE 5801*/
        public IntBasis CVP_5801 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5801);
        /*"  03  CVP-5802                     PIC S9(004) COMP-5 VALUE 5802*/
        public IntBasis CVP_5802 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5802);
        /*"  03  CVP-5803                     PIC S9(004) COMP-5 VALUE 5803*/
        public IntBasis CVP_5803 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5803);
        /*"  03  CVP-5804                     PIC S9(004) COMP-5 VALUE 5804*/
        public IntBasis CVP_5804 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5804);
        /*"  03  CVP-5805                     PIC S9(004) COMP-5 VALUE 5805*/
        public IntBasis CVP_5805 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5805);
        /*"  03  CVP-5806                     PIC S9(004) COMP-5 VALUE 5806*/
        public IntBasis CVP_5806 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5806);
        /*"  03  CVP-5807                     PIC S9(004) COMP-5 VALUE 5807*/
        public IntBasis CVP_5807 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5807);
        /*"  03  CVP-5808                     PIC S9(004) COMP-5 VALUE 5808*/
        public IntBasis CVP_5808 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5808);
        /*"  03  CVP-5809                     PIC S9(004) COMP-5 VALUE 5809*/
        public IntBasis CVP_5809 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5809);
        /*"  03  CVP-5810                     PIC S9(004) COMP-5 VALUE 5810*/
        public IntBasis CVP_5810 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5810);
        /*"  03  CVP-5811                     PIC S9(004) COMP-5 VALUE 5811*/
        public IntBasis CVP_5811 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5811);
        /*"  03  CVP-5812                     PIC S9(004) COMP-5 VALUE 5812*/
        public IntBasis CVP_5812 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5812);
        /*"  03  CVP-5813                     PIC S9(004) COMP-5 VALUE 5813*/
        public IntBasis CVP_5813 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5813);
        /*"  03  CVP-5814                     PIC S9(004) COMP-5 VALUE 5814*/
        public IntBasis CVP_5814 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5814);
        /*"  03  CVP-5815                     PIC S9(004) COMP-5 VALUE 5815*/
        public IntBasis CVP_5815 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5815);
        /*"  03  CVP-5816                     PIC S9(004) COMP-5 VALUE 5816*/
        public IntBasis CVP_5816 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5816);
        /*"  03  CVP-5817                     PIC S9(004) COMP-5 VALUE 5817*/
        public IntBasis CVP_5817 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5817);
        /*"  03  CVP-5818                     PIC S9(004) COMP-5 VALUE 5818*/
        public IntBasis CVP_5818 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5818);
        /*"  03  CVP-5819                     PIC S9(004) COMP-5 VALUE 5819*/
        public IntBasis CVP_5819 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5819);
        /*"  03  CVP-5820                     PIC S9(004) COMP-5 VALUE 5820*/
        public IntBasis CVP_5820 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5820);
        /*"  03  CVP-5821                     PIC S9(004) COMP-5 VALUE 5821*/
        public IntBasis CVP_5821 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5821);
        /*"  03  CVP-5822                     PIC S9(004) COMP-5 VALUE 5822*/
        public IntBasis CVP_5822 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5822);
        /*"  03  CVP-5823                     PIC S9(004) COMP-5 VALUE 5823*/
        public IntBasis CVP_5823 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5823);
        /*"  03  CVP-5824                     PIC S9(004) COMP-5 VALUE 5824*/
        public IntBasis CVP_5824 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5824);
        /*"  03  CVP-5825                     PIC S9(004) COMP-5 VALUE 5825*/
        public IntBasis CVP_5825 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5825);
        /*"  03  CVP-5826                     PIC S9(004) COMP-5 VALUE 5826*/
        public IntBasis CVP_5826 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5826);
        /*"  03  CVP-5827                     PIC S9(004) COMP-5 VALUE 5827*/
        public IntBasis CVP_5827 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5827);
        /*"  03  CVP-5828                     PIC S9(004) COMP-5 VALUE 5828*/
        public IntBasis CVP_5828 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5828);
        /*"  03  CVP-5829                     PIC S9(004) COMP-5 VALUE 5829*/
        public IntBasis CVP_5829 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5829);
        /*"  03  CVP-5830                     PIC S9(004) COMP-5 VALUE 5830*/
        public IntBasis CVP_5830 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5830);
        /*"  03  CVP-5831                     PIC S9(004) COMP-5 VALUE 5831*/
        public IntBasis CVP_5831 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5831);
        /*"  03  CVP-5832                     PIC S9(004) COMP-5 VALUE 5832*/
        public IntBasis CVP_5832 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5832);
        /*"  03  CVP-5833                     PIC S9(004) COMP-5 VALUE 5833*/
        public IntBasis CVP_5833 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5833);
        /*"  03  CVP-5834                     PIC S9(004) COMP-5 VALUE 5834*/
        public IntBasis CVP_5834 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5834);
        /*"  03  CVP-5835                     PIC S9(004) COMP-5 VALUE 5835*/
        public IntBasis CVP_5835 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5835);
        /*"  03  CVP-5836                     PIC S9(004) COMP-5 VALUE 5836*/
        public IntBasis CVP_5836 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5836);
        /*"  03  CVP-5837                     PIC S9(004) COMP-5 VALUE 5837*/
        public IntBasis CVP_5837 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5837);
        /*"  03  CVP-5838                     PIC S9(004) COMP-5 VALUE 5838*/
        public IntBasis CVP_5838 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5838);
        /*"  03  CVP-5839                     PIC S9(004) COMP-5 VALUE 5839*/
        public IntBasis CVP_5839 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5839);
        /*"  03  CVP-5840                     PIC S9(004) COMP-5 VALUE 5840*/
        public IntBasis CVP_5840 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5840);
        /*"  03  CVP-5841                     PIC S9(004) COMP-5 VALUE 5841*/
        public IntBasis CVP_5841 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5841);
        /*"  03  CVP-5842                     PIC S9(004) COMP-5 VALUE 5842*/
        public IntBasis CVP_5842 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5842);
        /*"  03  CVP-5843                     PIC S9(004) COMP-5 VALUE 5843*/
        public IntBasis CVP_5843 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5843);
        /*"  03  CVP-5844                     PIC S9(004) COMP-5 VALUE 5844*/
        public IntBasis CVP_5844 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5844);
        /*"  03  CVP-5845                     PIC S9(004) COMP-5 VALUE 5845*/
        public IntBasis CVP_5845 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5845);
        /*"  03  CVP-5846                     PIC S9(004) COMP-5 VALUE 5846*/
        public IntBasis CVP_5846 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5846);
        /*"  03  CVP-5847                     PIC S9(004) COMP-5 VALUE 5847*/
        public IntBasis CVP_5847 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 5847);
        /*"  03  CVP-6901                     PIC S9(004) COMP-5 VALUE 6901*/
        public IntBasis CVP_6901 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6901);
        /*"  03  CVP-6902                     PIC S9(004) COMP-5 VALUE 6902*/
        public IntBasis CVP_6902 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6902);
        /*"  03  CVP-6903                     PIC S9(004) COMP-5 VALUE 6903*/
        public IntBasis CVP_6903 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6903);
        /*"  03  CVP-6904                     PIC S9(004) COMP-5 VALUE 6904*/
        public IntBasis CVP_6904 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6904);
        /*"  03  CVP-6905                     PIC S9(004) COMP-5 VALUE 6905*/
        public IntBasis CVP_6905 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6905);
        /*"  03  CVP-6906                     PIC S9(004) COMP-5 VALUE 6906*/
        public IntBasis CVP_6906 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6906);
        /*"  03  CVP-6907                     PIC S9(004) COMP-5 VALUE 6907*/
        public IntBasis CVP_6907 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6907);
        /*"  03  CVP-6908                     PIC S9(004) COMP-5 VALUE 6908*/
        public IntBasis CVP_6908 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6908);
        /*"  03  CVP-6909                     PIC S9(004) COMP-5 VALUE 6909*/
        public IntBasis CVP_6909 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6909);
        /*"  03  CVP-6910                     PIC S9(004) COMP-5 VALUE 6910*/
        public IntBasis CVP_6910 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6910);
        /*"  03  CVP-6911                     PIC S9(004) COMP-5 VALUE 6911*/
        public IntBasis CVP_6911 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6911);
        /*"  03  CVP-6912                     PIC S9(004) COMP-5 VALUE 6912*/
        public IntBasis CVP_6912 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6912);
        /*"  03  CVP-6913                     PIC S9(004) COMP-5 VALUE 6913*/
        public IntBasis CVP_6913 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6913);
        /*"  03  CVP-6914                     PIC S9(004) COMP-5 VALUE 6914*/
        public IntBasis CVP_6914 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6914);
        /*"  03  CVP-6915                     PIC S9(004) COMP-5 VALUE 6915*/
        public IntBasis CVP_6915 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6915);
        /*"  03  CVP-6916                     PIC S9(004) COMP-5 VALUE 6916*/
        public IntBasis CVP_6916 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6916);
        /*"  03  CVP-6917                     PIC S9(004) COMP-5 VALUE 6917*/
        public IntBasis CVP_6917 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6917);
        /*"  03  CVP-6918                     PIC S9(004) COMP-5 VALUE 6918*/
        public IntBasis CVP_6918 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6918);
        /*"  03  CVP-6919                     PIC S9(004) COMP-5 VALUE 6919*/
        public IntBasis CVP_6919 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6919);
        /*"  03  CVP-6920                     PIC S9(004) COMP-5 VALUE 6920*/
        public IntBasis CVP_6920 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6920);
        /*"  03  CVP-6921                     PIC S9(004) COMP-5 VALUE 6921*/
        public IntBasis CVP_6921 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6921);
        /*"  03  CVP-6922                     PIC S9(004) COMP-5 VALUE 6922*/
        public IntBasis CVP_6922 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6922);
        /*"  03  CVP-6923                     PIC S9(004) COMP-5 VALUE 6923*/
        public IntBasis CVP_6923 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6923);
        /*"  03  CVP-6924                     PIC S9(004) COMP-5 VALUE 6924*/
        public IntBasis CVP_6924 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6924);
        /*"  03  CVP-6925                     PIC S9(004) COMP-5 VALUE 6925*/
        public IntBasis CVP_6925 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6925);
        /*"  03  CVP-6926                     PIC S9(004) COMP-5 VALUE 6926*/
        public IntBasis CVP_6926 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6926);
        /*"  03  CVP-6988                     PIC S9(004) COMP-5 VALUE 6988*/
        public IntBasis CVP_6988 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6988);
        /*"  03  CVP-6989                     PIC S9(004) COMP-5 VALUE 6989*/
        public IntBasis CVP_6989 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6989);
        /*"  03  CVP-7701                     PIC S9(004) COMP-5 VALUE 7701*/
        public IntBasis CVP_7701 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7701);
        /*"  03  CVP-7702                     PIC S9(004) COMP-5 VALUE 7702*/
        public IntBasis CVP_7702 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7702);
        /*"  03  CVP-7703                     PIC S9(004) COMP-5 VALUE 7703*/
        public IntBasis CVP_7703 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7703);
        /*"  03  CVP-7704                     PIC S9(004) COMP-5 VALUE 7704*/
        public IntBasis CVP_7704 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7704);
        /*"  03  CVP-7705                     PIC S9(004) COMP-5 VALUE 7705*/
        public IntBasis CVP_7705 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7705);
        /*"  03  CVP-7706                     PIC S9(004) COMP-5 VALUE 7706*/
        public IntBasis CVP_7706 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7706);
        /*"  03  CVP-7707                     PIC S9(004) COMP-5 VALUE 7707*/
        public IntBasis CVP_7707 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7707);
        /*"  03  CVP-7708                     PIC S9(004) COMP-5 VALUE 7708*/
        public IntBasis CVP_7708 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7708);
        /*"  03  CVP-7709                     PIC S9(004) COMP-5 VALUE 7709*/
        public IntBasis CVP_7709 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7709);
        /*"  03  CVP-7710                     PIC S9(004) COMP-5 VALUE 7710*/
        public IntBasis CVP_7710 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7710);
        /*"  03  CVP-7711                     PIC S9(004) COMP-5 VALUE 7711*/
        public IntBasis CVP_7711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7711);
        /*"  03  CVP-7712                     PIC S9(004) COMP-5 VALUE 7712*/
        public IntBasis CVP_7712 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7712);
        /*"  03  CVP-7713                     PIC S9(004) COMP-5 VALUE 7713*/
        public IntBasis CVP_7713 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7713);
        /*"  03  CVP-7714                     PIC S9(004) COMP-5 VALUE 7714*/
        public IntBasis CVP_7714 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7714);
        /*"  03  CVP-7715                     PIC S9(004) COMP-5 VALUE 7715*/
        public IntBasis CVP_7715 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7715);
        /*"  03  CVP-7716                     PIC S9(004) COMP-5 VALUE 7716*/
        public IntBasis CVP_7716 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7716);
        /*"  03  CVP-7717                     PIC S9(004) COMP-5 VALUE 7717*/
        public IntBasis CVP_7717 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7717);
        /*"  03  CVP-7718                     PIC S9(004) COMP-5 VALUE 7718*/
        public IntBasis CVP_7718 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7718);
        /*"  03  CVP-7719                     PIC S9(004) COMP-5 VALUE 7719*/
        public IntBasis CVP_7719 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7719);
        /*"  03  CVP-7720                     PIC S9(004) COMP-5 VALUE 7720*/
        public IntBasis CVP_7720 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7720);
        /*"  03  CVP-7721                     PIC S9(004) COMP-5 VALUE 7721*/
        public IntBasis CVP_7721 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7721);
        /*"  03  CVP-7722                     PIC S9(004) COMP-5 VALUE 7722*/
        public IntBasis CVP_7722 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7722);
        /*"  03  CVP-7723                     PIC S9(004) COMP-5 VALUE 7723*/
        public IntBasis CVP_7723 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7723);
        /*"  03  CVP-7724                     PIC S9(004) COMP-5 VALUE 7724*/
        public IntBasis CVP_7724 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7724);
        /*"  03  CVP-7725                     PIC S9(004) COMP-5 VALUE 7725*/
        public IntBasis CVP_7725 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7725);
        /*"  03  CVP-7726                     PIC S9(004) COMP-5 VALUE 7726*/
        public IntBasis CVP_7726 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7726);
        /*"  03  CVP-7727                     PIC S9(004) COMP-5 VALUE 7727*/
        public IntBasis CVP_7727 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7727);
        /*"  03  CVP-7728                     PIC S9(004) COMP-5 VALUE 7728*/
        public IntBasis CVP_7728 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7728);
        /*"  03  CVP-7729                     PIC S9(004) COMP-5 VALUE 7729*/
        public IntBasis CVP_7729 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7729);
        /*"  03  CVP-7730                     PIC S9(004) COMP-5 VALUE 7730*/
        public IntBasis CVP_7730 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7730);
        /*"  03  CVP-7731                     PIC S9(004) COMP-5 VALUE 7731*/
        public IntBasis CVP_7731 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7731);
        /*"  03  CVP-7732                     PIC S9(004) COMP-5 VALUE 7732*/
        public IntBasis CVP_7732 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7732);
        /*"  03  CVP-7733                     PIC S9(004) COMP-5 VALUE 7733*/
        public IntBasis CVP_7733 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7733);
        /*"  03  CVP-7734                     PIC S9(004) COMP-5 VALUE 7734*/
        public IntBasis CVP_7734 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7734);
        /*"  03  CVP-7735                     PIC S9(004) COMP-5 VALUE 7735*/
        public IntBasis CVP_7735 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7735);
        /*"  03  CVP-7736                     PIC S9(004) COMP-5 VALUE 7736*/
        public IntBasis CVP_7736 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7736);
        /*"  03  CVP-7737                     PIC S9(004) COMP-5 VALUE 7737*/
        public IntBasis CVP_7737 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7737);
        /*"  03  CVP-7738                     PIC S9(004) COMP-5 VALUE 7738*/
        public IntBasis CVP_7738 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7738);
        /*"  03  CVP-7799                     PIC S9(004) COMP-5 VALUE 7799*/
        public IntBasis CVP_7799 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7799);
        /*"  03  CVP-8099                     PIC S9(004) COMP-5 VALUE 8099*/
        public IntBasis CVP_8099 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8099);
        /*"  03  CVP-8101                     PIC S9(004) COMP-5 VALUE 8101*/
        public IntBasis CVP_8101 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8101);
        /*"  03  CVP-8102                     PIC S9(004) COMP-5 VALUE 8102*/
        public IntBasis CVP_8102 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8102);
        /*"  03  CVP-8103                     PIC S9(004) COMP-5 VALUE 8103*/
        public IntBasis CVP_8103 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8103);
        /*"  03  CVP-8104                     PIC S9(004) COMP-5 VALUE 8104*/
        public IntBasis CVP_8104 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8104);
        /*"  03  CVP-8105                     PIC S9(004) COMP-5 VALUE 8105*/
        public IntBasis CVP_8105 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8105);
        /*"  03  CVP-8106                     PIC S9(004) COMP-5 VALUE 8106*/
        public IntBasis CVP_8106 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8106);
        /*"  03  CVP-8107                     PIC S9(004) COMP-5 VALUE 8107*/
        public IntBasis CVP_8107 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8107);
        /*"  03  CVP-8108                     PIC S9(004) COMP-5 VALUE 8108*/
        public IntBasis CVP_8108 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8108);
        /*"  03  CVP-8109                     PIC S9(004) COMP-5 VALUE 8109*/
        public IntBasis CVP_8109 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8109);
        /*"  03  CVP-8110                     PIC S9(004) COMP-5 VALUE 8110*/
        public IntBasis CVP_8110 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8110);
        /*"  03  CVP-8111                     PIC S9(004) COMP-5 VALUE 8111*/
        public IntBasis CVP_8111 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8111);
        /*"  03  CVP-8112                     PIC S9(004) COMP-5 VALUE 8112*/
        public IntBasis CVP_8112 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8112);
        /*"  03  CVP-8113                     PIC S9(004) COMP-5 VALUE 8113*/
        public IntBasis CVP_8113 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8113);
        /*"  03  CVP-8114                     PIC S9(004) COMP-5 VALUE 8114*/
        public IntBasis CVP_8114 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8114);
        /*"  03  CVP-8115                     PIC S9(004) COMP-5 VALUE 8115*/
        public IntBasis CVP_8115 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8115);
        /*"  03  CVP-8116                     PIC S9(004) COMP-5 VALUE 8116*/
        public IntBasis CVP_8116 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8116);
        /*"  03  CVP-8117                     PIC S9(004) COMP-5 VALUE 8117*/
        public IntBasis CVP_8117 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8117);
        /*"  03  CVP-8118                     PIC S9(004) COMP-5 VALUE 8118*/
        public IntBasis CVP_8118 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8118);
        /*"  03  CVP-8119                     PIC S9(004) COMP-5 VALUE 8119*/
        public IntBasis CVP_8119 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8119);
        /*"  03  CVP-8120                     PIC S9(004) COMP-5 VALUE 8120*/
        public IntBasis CVP_8120 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8120);
        /*"  03  CVP-8121                     PIC S9(004) COMP-5 VALUE 8121*/
        public IntBasis CVP_8121 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8121);
        /*"  03  CVP-8122                     PIC S9(004) COMP-5 VALUE 8122*/
        public IntBasis CVP_8122 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8122);
        /*"  03  CVP-8123                     PIC S9(004) COMP-5 VALUE 8123*/
        public IntBasis CVP_8123 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8123);
        /*"  03  CVP-8124                     PIC S9(004) COMP-5 VALUE 8124*/
        public IntBasis CVP_8124 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8124);
        /*"  03  CVP-8125                     PIC S9(004) COMP-5 VALUE 8125*/
        public IntBasis CVP_8125 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8125);
        /*"  03  CVP-8126                     PIC S9(004) COMP-5 VALUE 8126*/
        public IntBasis CVP_8126 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8126);
        /*"  03  CVP-8127                     PIC S9(004) COMP-5 VALUE 8127*/
        public IntBasis CVP_8127 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8127);
        /*"  03  CVP-8128                     PIC S9(004) COMP-5 VALUE 8128*/
        public IntBasis CVP_8128 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8128);
        /*"  03  CVP-8129                     PIC S9(004) COMP-5 VALUE 8129*/
        public IntBasis CVP_8129 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8129);
        /*"  03  CVP-8130                     PIC S9(004) COMP-5 VALUE 8130*/
        public IntBasis CVP_8130 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8130);
        /*"  03  CVP-8131                     PIC S9(004) COMP-5 VALUE 8131*/
        public IntBasis CVP_8131 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8131);
        /*"  03  CVP-8132                     PIC S9(004) COMP-5 VALUE 8132*/
        public IntBasis CVP_8132 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8132);
        /*"  03  CVP-8133                     PIC S9(004) COMP-5 VALUE 8133*/
        public IntBasis CVP_8133 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8133);
        /*"  03  CVP-8134                     PIC S9(004) COMP-5 VALUE 8134*/
        public IntBasis CVP_8134 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8134);
        /*"  03  CVP-8135                     PIC S9(004) COMP-5 VALUE 8135*/
        public IntBasis CVP_8135 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8135);
        /*"  03  CVP-8136                     PIC S9(004) COMP-5 VALUE 8136*/
        public IntBasis CVP_8136 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8136);
        /*"  03  CVP-8137                     PIC S9(004) COMP-5 VALUE 8137*/
        public IntBasis CVP_8137 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8137);
        /*"  03  CVP-8138                     PIC S9(004) COMP-5 VALUE 8138*/
        public IntBasis CVP_8138 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8138);
        /*"  03  CVP-8139                     PIC S9(004) COMP-5 VALUE 8139*/
        public IntBasis CVP_8139 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8139);
        /*"  03  CVP-8140                     PIC S9(004) COMP-5 VALUE 8140*/
        public IntBasis CVP_8140 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8140);
        /*"  03  CVP-8141                     PIC S9(004) COMP-5 VALUE 8141*/
        public IntBasis CVP_8141 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8141);
        /*"  03  CVP-8142                     PIC S9(004) COMP-5 VALUE 8142*/
        public IntBasis CVP_8142 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8142);
        /*"  03  CVP-8143                     PIC S9(004) COMP-5 VALUE 8143*/
        public IntBasis CVP_8143 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8143);
        /*"  03  CVP-8144                     PIC S9(004) COMP-5 VALUE 8144*/
        public IntBasis CVP_8144 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8144);
        /*"  03  CVP-8145                     PIC S9(004) COMP-5 VALUE 8145*/
        public IntBasis CVP_8145 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8145);
        /*"  03  CVP-8146                     PIC S9(004) COMP-5 VALUE 8146*/
        public IntBasis CVP_8146 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8146);
        /*"  03  CVP-8147                     PIC S9(004) COMP-5 VALUE 8147*/
        public IntBasis CVP_8147 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8147);
        /*"  03  CVP-8148                     PIC S9(004) COMP-5 VALUE 8148*/
        public IntBasis CVP_8148 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8148);
        /*"  03  CVP-8149                     PIC S9(004) COMP-5 VALUE 8149*/
        public IntBasis CVP_8149 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8149);
        /*"  03  CVP-8150                     PIC S9(004) COMP-5 VALUE 8150*/
        public IntBasis CVP_8150 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8150);
        /*"  03  CVP-8151                     PIC S9(004) COMP-5 VALUE 8151*/
        public IntBasis CVP_8151 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8151);
        /*"  03  CVP-8152                     PIC S9(004) COMP-5 VALUE 8152*/
        public IntBasis CVP_8152 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8152);
        /*"  03  CVP-8153                     PIC S9(004) COMP-5 VALUE 8153*/
        public IntBasis CVP_8153 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8153);
        /*"  03  CVP-8154                     PIC S9(004) COMP-5 VALUE 8154*/
        public IntBasis CVP_8154 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8154);
        /*"  03  CVP-8155                     PIC S9(004) COMP-5 VALUE 8155*/
        public IntBasis CVP_8155 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8155);
        /*"  03  CVP-8156                     PIC S9(004) COMP-5 VALUE 8156*/
        public IntBasis CVP_8156 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8156);
        /*"  03  CVP-8157                     PIC S9(004) COMP-5 VALUE 8157*/
        public IntBasis CVP_8157 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8157);
        /*"  03  CVP-8158                     PIC S9(004) COMP-5 VALUE 8158*/
        public IntBasis CVP_8158 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8158);
        /*"  03  CVP-8159                     PIC S9(004) COMP-5 VALUE 8159*/
        public IntBasis CVP_8159 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8159);
        /*"  03  CVP-8160                     PIC S9(004) COMP-5 VALUE 8160*/
        public IntBasis CVP_8160 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8160);
        /*"  03  CVP-8161                     PIC S9(004) COMP-5 VALUE 8161*/
        public IntBasis CVP_8161 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8161);
        /*"  03  CVP-8162                     PIC S9(004) COMP-5 VALUE 8162*/
        public IntBasis CVP_8162 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8162);
        /*"  03  CVP-8163                     PIC S9(004) COMP-5 VALUE 8163*/
        public IntBasis CVP_8163 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8163);
        /*"  03  CVP-8164                     PIC S9(004) COMP-5 VALUE 8164*/
        public IntBasis CVP_8164 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8164);
        /*"  03  CVP-8165                     PIC S9(004) COMP-5 VALUE 8165*/
        public IntBasis CVP_8165 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8165);
        /*"  03  CVP-8166                     PIC S9(004) COMP-5 VALUE 8166*/
        public IntBasis CVP_8166 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8166);
        /*"  03  CVP-8167                     PIC S9(004) COMP-5 VALUE 8167*/
        public IntBasis CVP_8167 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8167);
        /*"  03  CVP-8168                     PIC S9(004) COMP-5 VALUE 8168*/
        public IntBasis CVP_8168 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8168);
        /*"  03  CVP-8169                     PIC S9(004) COMP-5 VALUE 8169*/
        public IntBasis CVP_8169 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8169);
        /*"  03  CVP-8170                     PIC S9(004) COMP-5 VALUE 8170*/
        public IntBasis CVP_8170 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8170);
        /*"  03  CVP-8171                     PIC S9(004) COMP-5 VALUE 8171*/
        public IntBasis CVP_8171 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8171);
        /*"  03  CVP-8172                     PIC S9(004) COMP-5 VALUE 8172*/
        public IntBasis CVP_8172 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8172);
        /*"  03  CVP-8173                     PIC S9(004) COMP-5 VALUE 8173*/
        public IntBasis CVP_8173 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8173);
        /*"  03  CVP-8174                     PIC S9(004) COMP-5 VALUE 8174*/
        public IntBasis CVP_8174 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8174);
        /*"  03  CVP-8175                     PIC S9(004) COMP-5 VALUE 8175*/
        public IntBasis CVP_8175 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8175);
        /*"  03  CVP-8176                     PIC S9(004) COMP-5 VALUE 8176*/
        public IntBasis CVP_8176 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8176);
        /*"  03  CVP-8177                     PIC S9(004) COMP-5 VALUE 8177*/
        public IntBasis CVP_8177 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8177);
        /*"  03  CVP-8178                     PIC S9(004) COMP-5 VALUE 8178*/
        public IntBasis CVP_8178 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8178);
        /*"  03  CVP-8179                     PIC S9(004) COMP-5 VALUE 8179*/
        public IntBasis CVP_8179 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8179);
        /*"  03  CVP-8180                     PIC S9(004) COMP-5 VALUE 8180*/
        public IntBasis CVP_8180 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8180);
        /*"  03  CVP-8181                     PIC S9(004) COMP-5 VALUE 8181*/
        public IntBasis CVP_8181 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8181);
        /*"  03  CVP-8182                     PIC S9(004) COMP-5 VALUE 8182*/
        public IntBasis CVP_8182 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8182);
        /*"  03  CVP-8183                     PIC S9(004) COMP-5 VALUE 8183*/
        public IntBasis CVP_8183 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8183);
        /*"  03  CVP-8184                     PIC S9(004) COMP-5 VALUE 8184*/
        public IntBasis CVP_8184 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8184);
        /*"  03  CVP-8185                     PIC S9(004) COMP-5 VALUE 8185*/
        public IntBasis CVP_8185 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8185);
        /*"  03  CVP-8186                     PIC S9(004) COMP-5 VALUE 8186*/
        public IntBasis CVP_8186 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8186);
        /*"  03  CVP-8187                     PIC S9(004) COMP-5 VALUE 8187*/
        public IntBasis CVP_8187 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8187);
        /*"  03  CVP-8188                     PIC S9(004) COMP-5 VALUE 8188*/
        public IntBasis CVP_8188 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8188);
        /*"  03  CVP-8189                     PIC S9(004) COMP-5 VALUE 8189*/
        public IntBasis CVP_8189 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8189);
        /*"  03  CVP-8190                     PIC S9(004) COMP-5 VALUE 8190*/
        public IntBasis CVP_8190 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8190);
        /*"  03  CVP-8191                     PIC S9(004) COMP-5 VALUE 8191*/
        public IntBasis CVP_8191 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8191);
        /*"  03  CVP-8199                     PIC S9(004) COMP-5 VALUE 8199*/
        public IntBasis CVP_8199 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8199);
        /*"  03  CVP-8201                     PIC S9(004) COMP-5 VALUE 8201*/
        public IntBasis CVP_8201 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8201);
        /*"  03  CVP-8202                     PIC S9(004) COMP-5 VALUE 8202*/
        public IntBasis CVP_8202 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8202);
        /*"  03  CVP-8203                     PIC S9(004) COMP-5 VALUE 8203*/
        public IntBasis CVP_8203 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8203);
        /*"  03  CVP-8204                     PIC S9(004) COMP-5 VALUE 8204*/
        public IntBasis CVP_8204 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8204);
        /*"  03  CVP-9294                     PIC S9(004) COMP-5 VALUE 9294*/
        public IntBasis CVP_9294 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9294);
        /*"  03  CVP-8205                     PIC S9(004) COMP-5 VALUE 8205*/
        public IntBasis CVP_8205 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8205);
        /*"  03  CVP-8206                     PIC S9(004) COMP-5 VALUE 8206*/
        public IntBasis CVP_8206 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8206);
        /*"  03  CVP-8207                     PIC S9(004) COMP-5 VALUE 8207*/
        public IntBasis CVP_8207 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8207);
        /*"  03  CVP-8208                     PIC S9(004) COMP-5 VALUE 8208*/
        public IntBasis CVP_8208 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8208);
        /*"  03  CVP-8209                     PIC S9(004) COMP-5 VALUE 8209*/
        public IntBasis CVP_8209 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8209);
        /*"  03  CVP-8210                     PIC S9(004) COMP-5 VALUE 8210*/
        public IntBasis CVP_8210 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8210);
        /*"  03  CVP-8211                     PIC S9(004) COMP-5 VALUE 8211*/
        public IntBasis CVP_8211 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8211);
        /*"  03  CVP-8212                     PIC S9(004) COMP-5 VALUE 8212*/
        public IntBasis CVP_8212 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8212);
        /*"  03  CVP-8213                     PIC S9(004) COMP-5 VALUE 8213*/
        public IntBasis CVP_8213 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8213);
        /*"  03  CVP-8214                     PIC S9(004) COMP-5 VALUE 8214*/
        public IntBasis CVP_8214 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8214);
        /*"  03  CVP-8215                     PIC S9(004) COMP-5 VALUE 8215*/
        public IntBasis CVP_8215 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8215);
        /*"  03  CVP-8216                     PIC S9(004) COMP-5 VALUE 8216*/
        public IntBasis CVP_8216 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8216);
        /*"  03  CVP-8217                     PIC S9(004) COMP-5 VALUE 8217*/
        public IntBasis CVP_8217 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8217);
        /*"  03  CVP-8218                     PIC S9(004) COMP-5 VALUE 8218*/
        public IntBasis CVP_8218 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8218);
        /*"  03  CVP-8219                     PIC S9(004) COMP-5 VALUE 8219*/
        public IntBasis CVP_8219 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8219);
        /*"  03  CVP-8220                     PIC S9(004) COMP-5 VALUE 8220*/
        public IntBasis CVP_8220 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8220);
        /*"  03  CVP-8221                     PIC S9(004) COMP-5 VALUE 8221*/
        public IntBasis CVP_8221 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8221);
        /*"  03  CVP-8222                     PIC S9(004) COMP-5 VALUE 8222*/
        public IntBasis CVP_8222 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8222);
        /*"  03  CVP-8223                     PIC S9(004) COMP-5 VALUE 8223*/
        public IntBasis CVP_8223 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8223);
        /*"  03  CVP-8224                     PIC S9(004) COMP-5 VALUE 8224*/
        public IntBasis CVP_8224 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8224);
        /*"  03  CVP-8225                     PIC S9(004) COMP-5 VALUE 8225*/
        public IntBasis CVP_8225 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8225);
        /*"  03  CVP-8226                     PIC S9(004) COMP-5 VALUE 8226*/
        public IntBasis CVP_8226 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8226);
        /*"  03  CVP-8227                     PIC S9(004) COMP-5 VALUE 8227*/
        public IntBasis CVP_8227 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8227);
        /*"  03  CVP-8228                     PIC S9(004) COMP-5 VALUE 8228*/
        public IntBasis CVP_8228 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8228);
        /*"  03  CVP-8229                     PIC S9(004) COMP-5 VALUE 8229*/
        public IntBasis CVP_8229 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8229);
        /*"  03  CVP-8230                     PIC S9(004) COMP-5 VALUE 8230*/
        public IntBasis CVP_8230 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8230);
        /*"  03  CVP-8231                     PIC S9(004) COMP-5 VALUE 8231*/
        public IntBasis CVP_8231 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8231);
        /*"  03  CVP-8232                     PIC S9(004) COMP-5 VALUE 8232*/
        public IntBasis CVP_8232 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8232);
        /*"  03  CVP-8234                     PIC S9(004) COMP-5 VALUE 8234*/
        public IntBasis CVP_8234 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8234);
        /*"  03  CVP-8235                     PIC S9(004) COMP-5 VALUE 8235*/
        public IntBasis CVP_8235 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8235);
        /*"  03  CVP-8236                     PIC S9(004) COMP-5 VALUE 8236*/
        public IntBasis CVP_8236 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8236);
        /*"  03  CVP-8288                     PIC S9(004) COMP-5 VALUE 8288*/
        public IntBasis CVP_8288 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8288);
        /*"  03  CVP-8289                     PIC S9(004) COMP-5 VALUE 8289*/
        public IntBasis CVP_8289 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8289);
        /*"  03  CVP-8299                     PIC S9(004) COMP-5 VALUE 8299*/
        public IntBasis CVP_8299 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8299);
        /*"  03  CVP-9101                     PIC S9(004) COMP-5 VALUE 9101*/
        public IntBasis CVP_9101 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9101);
        /*"  03  CVP-9102                     PIC S9(004) COMP-5 VALUE 9102*/
        public IntBasis CVP_9102 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9102);
        /*"  03  CVP-9103                     PIC S9(004) COMP-5 VALUE 9103*/
        public IntBasis CVP_9103 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9103);
        /*"  03  CVP-9104                     PIC S9(004) COMP-5 VALUE 9104*/
        public IntBasis CVP_9104 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9104);
        /*"  03  CVP-9105                     PIC S9(004) COMP-5 VALUE 9105*/
        public IntBasis CVP_9105 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9105);
        /*"  03  CVP-9106                     PIC S9(004) COMP-5 VALUE 9106*/
        public IntBasis CVP_9106 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9106);
        /*"  03  CVP-9107                     PIC S9(004) COMP-5 VALUE 9107*/
        public IntBasis CVP_9107 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9107);
        /*"  03  CVP-9188                     PIC S9(004) COMP-5 VALUE 9188*/
        public IntBasis CVP_9188 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9188);
        /*"  03  CVP-9189                     PIC S9(004) COMP-5 VALUE 9189*/
        public IntBasis CVP_9189 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9189);
        /*"  03  CVP-9201                     PIC S9(004) COMP-5 VALUE 9201*/
        public IntBasis CVP_9201 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9201);
        /*"  03  CVP-9202                     PIC S9(004) COMP-5 VALUE 9202*/
        public IntBasis CVP_9202 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9202);
        /*"  03  CVP-9203                     PIC S9(004) COMP-5 VALUE 9203*/
        public IntBasis CVP_9203 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9203);
        /*"  03  CVP-9204                     PIC S9(004) COMP-5 VALUE 9204*/
        public IntBasis CVP_9204 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9204);
        /*"  03  CVP-9205                     PIC S9(004) COMP-5 VALUE 9205*/
        public IntBasis CVP_9205 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9205);
        /*"  03  CVP-9206                     PIC S9(004) COMP-5 VALUE 9206*/
        public IntBasis CVP_9206 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9206);
        /*"  03  CVP-9207                     PIC S9(004) COMP-5 VALUE 9207*/
        public IntBasis CVP_9207 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9207);
        /*"  03  CVP-9208                     PIC S9(004) COMP-5 VALUE 9208*/
        public IntBasis CVP_9208 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9208);
        /*"  03  CVP-9209                     PIC S9(004) COMP-5 VALUE 9209*/
        public IntBasis CVP_9209 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9209);
        /*"  03  CVP-9210                     PIC S9(004) COMP-5 VALUE 9210*/
        public IntBasis CVP_9210 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9210);
        /*"  03  CVP-9211                     PIC S9(004) COMP-5 VALUE 9211*/
        public IntBasis CVP_9211 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9211);
        /*"  03  CVP-9212                     PIC S9(004) COMP-5 VALUE 9212*/
        public IntBasis CVP_9212 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9212);
        /*"  03  CVP-9213                     PIC S9(004) COMP-5 VALUE 9213*/
        public IntBasis CVP_9213 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9213);
        /*"  03  CVP-9214                     PIC S9(004) COMP-5 VALUE 9214*/
        public IntBasis CVP_9214 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9214);
        /*"  03  CVP-9215                     PIC S9(004) COMP-5 VALUE 9215*/
        public IntBasis CVP_9215 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9215);
        /*"  03  CVP-9216                     PIC S9(004) COMP-5 VALUE 9216*/
        public IntBasis CVP_9216 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9216);
        /*"  03  CVP-9217                     PIC S9(004) COMP-5 VALUE 9217*/
        public IntBasis CVP_9217 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9217);
        /*"  03  CVP-9218                     PIC S9(004) COMP-5 VALUE 9218*/
        public IntBasis CVP_9218 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9218);
        /*"  03  CVP-9219                     PIC S9(004) COMP-5 VALUE 9219*/
        public IntBasis CVP_9219 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9219);
        /*"  03  CVP-9220                     PIC S9(004) COMP-5 VALUE 9220*/
        public IntBasis CVP_9220 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9220);
        /*"  03  CVP-9221                     PIC S9(004) COMP-5 VALUE 9221*/
        public IntBasis CVP_9221 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9221);
        /*"  03  CVP-9222                     PIC S9(004) COMP-5 VALUE 9222*/
        public IntBasis CVP_9222 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9222);
        /*"  03  CVP-9223                     PIC S9(004) COMP-5 VALUE 9223*/
        public IntBasis CVP_9223 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9223);
        /*"  03  CVP-9224                     PIC S9(004) COMP-5 VALUE 9224*/
        public IntBasis CVP_9224 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9224);
        /*"  03  CVP-9225                     PIC S9(004) COMP-5 VALUE 9225*/
        public IntBasis CVP_9225 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9225);
        /*"  03  CVP-9226                     PIC S9(004) COMP-5 VALUE 9226*/
        public IntBasis CVP_9226 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9226);
        /*"  03  CVP-9227                     PIC S9(004) COMP-5 VALUE 9227*/
        public IntBasis CVP_9227 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9227);
        /*"  03  CVP-9228                     PIC S9(004) COMP-5 VALUE 9228*/
        public IntBasis CVP_9228 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9228);
        /*"  03  CVP-9229                     PIC S9(004) COMP-5 VALUE 9229*/
        public IntBasis CVP_9229 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9229);
        /*"  03  CVP-9230                     PIC S9(004) COMP-5 VALUE 9230*/
        public IntBasis CVP_9230 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9230);
        /*"  03  CVP-9231                     PIC S9(004) COMP-5 VALUE 9231*/
        public IntBasis CVP_9231 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9231);
        /*"  03  CVP-9232                     PIC S9(004) COMP-5 VALUE 9232*/
        public IntBasis CVP_9232 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9232);
        /*"  03  CVP-9233                     PIC S9(004) COMP-5 VALUE 9233*/
        public IntBasis CVP_9233 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9233);
        /*"  03  CVP-9234                     PIC S9(004) COMP-5 VALUE 9234*/
        public IntBasis CVP_9234 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9234);
        /*"  03  CVP-9235                     PIC S9(004) COMP-5 VALUE 9235*/
        public IntBasis CVP_9235 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9235);
        /*"  03  CVP-9236                     PIC S9(004) COMP-5 VALUE 9236*/
        public IntBasis CVP_9236 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9236);
        /*"  03  CVP-9237                     PIC S9(004) COMP-5 VALUE 9237*/
        public IntBasis CVP_9237 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9237);
        /*"  03  CVP-9238                     PIC S9(004) COMP-5 VALUE 9238*/
        public IntBasis CVP_9238 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9238);
        /*"  03  CVP-9239                     PIC S9(004) COMP-5 VALUE 9239*/
        public IntBasis CVP_9239 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9239);
        /*"  03  CVP-9240                     PIC S9(004) COMP-5 VALUE 9240*/
        public IntBasis CVP_9240 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9240);
        /*"  03  CVP-9241                     PIC S9(004) COMP-5 VALUE 9241*/
        public IntBasis CVP_9241 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9241);
        /*"  03  CVP-9242                     PIC S9(004) COMP-5 VALUE 9242*/
        public IntBasis CVP_9242 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9242);
        /*"  03  CVP-9243                     PIC S9(004) COMP-5 VALUE 9243*/
        public IntBasis CVP_9243 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9243);
        /*"  03  CVP-9245                     PIC S9(004) COMP-5 VALUE 9245*/
        public IntBasis CVP_9245 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9245);
        /*"  03  CVP-9246                     PIC S9(004) COMP-5 VALUE 9246*/
        public IntBasis CVP_9246 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9246);
        /*"  03  CVP-9247                     PIC S9(004) COMP-5 VALUE 9247*/
        public IntBasis CVP_9247 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9247);
        /*"  03  CVP-9248                     PIC S9(004) COMP-5 VALUE 9248*/
        public IntBasis CVP_9248 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9248);
        /*"  03  CVP-9249                     PIC S9(004) COMP-5 VALUE 9249*/
        public IntBasis CVP_9249 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9249);
        /*"  03  CVP-9250                     PIC S9(004) COMP-5 VALUE 9250*/
        public IntBasis CVP_9250 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9250);
        /*"  03  CVP-9251                     PIC S9(004) COMP-5 VALUE 9251*/
        public IntBasis CVP_9251 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9251);
        /*"  03  CVP-9252                     PIC S9(004) COMP-5 VALUE 9252*/
        public IntBasis CVP_9252 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9252);
        /*"  03  CVP-9253                     PIC S9(004) COMP-5 VALUE 9253*/
        public IntBasis CVP_9253 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9253);
        /*"  03  CVP-9254                     PIC S9(004) COMP-5 VALUE 9254*/
        public IntBasis CVP_9254 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9254);
        /*"  03  CVP-9255                     PIC S9(004) COMP-5 VALUE 9255*/
        public IntBasis CVP_9255 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9255);
        /*"  03  CVP-9256                     PIC S9(004) COMP-5 VALUE 9256*/
        public IntBasis CVP_9256 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9256);
        /*"  03  CVP-9257                     PIC S9(004) COMP-5 VALUE 9257*/
        public IntBasis CVP_9257 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9257);
        /*"  03  CVP-9258                     PIC S9(004) COMP-5 VALUE 9258*/
        public IntBasis CVP_9258 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9258);
        /*"  03  CVP-9259                     PIC S9(004) COMP-5 VALUE 9259*/
        public IntBasis CVP_9259 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9259);
        /*"  03  CVP-9260                     PIC S9(004) COMP-5 VALUE 9260*/
        public IntBasis CVP_9260 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9260);
        /*"  03  CVP-9261                     PIC S9(004) COMP-5 VALUE 9261*/
        public IntBasis CVP_9261 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9261);
        /*"  03  CVP-9262                     PIC S9(004) COMP-5 VALUE 9262*/
        public IntBasis CVP_9262 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9262);
        /*"  03  CVP-9263                     PIC S9(004) COMP-5 VALUE 9263*/
        public IntBasis CVP_9263 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9263);
        /*"  03  CVP-9264                     PIC S9(004) COMP-5 VALUE 9264*/
        public IntBasis CVP_9264 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9264);
        /*"  03  CVP-9265                     PIC S9(004) COMP-5 VALUE 9265*/
        public IntBasis CVP_9265 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9265);
        /*"  03  CVP-9266                     PIC S9(004) COMP-5 VALUE 9266*/
        public IntBasis CVP_9266 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9266);
        /*"  03  CVP-9267                     PIC S9(004) COMP-5 VALUE 9267*/
        public IntBasis CVP_9267 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9267);
        /*"  03  CVP-9268                     PIC S9(004) COMP-5 VALUE 9268*/
        public IntBasis CVP_9268 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9268);
        /*"  03  CVP-9269                     PIC S9(004) COMP-5 VALUE 9269*/
        public IntBasis CVP_9269 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9269);
        /*"  03  CVP-9270                     PIC S9(004) COMP-5 VALUE 9270*/
        public IntBasis CVP_9270 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9270);
        /*"  03  CVP-9271                     PIC S9(004) COMP-5 VALUE 9271*/
        public IntBasis CVP_9271 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9271);
        /*"  03  CVP-9272                     PIC S9(004) COMP-5 VALUE 9272*/
        public IntBasis CVP_9272 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9272);
        /*"  03  CVP-9273                     PIC S9(004) COMP-5 VALUE 9273*/
        public IntBasis CVP_9273 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9273);
        /*"  03  CVP-9274                     PIC S9(004) COMP-5 VALUE 9274*/
        public IntBasis CVP_9274 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9274);
        /*"  03  CVP-9275                     PIC S9(004) COMP-5 VALUE 9275*/
        public IntBasis CVP_9275 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9275);
        /*"  03  CVP-9276                     PIC S9(004) COMP-5 VALUE 9276*/
        public IntBasis CVP_9276 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9276);
        /*"  03  CVP-9277                     PIC S9(004) COMP-5 VALUE 9277*/
        public IntBasis CVP_9277 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9277);
        /*"  03  CVP-9278                     PIC S9(004) COMP-5 VALUE 9278*/
        public IntBasis CVP_9278 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9278);
        /*"  03  CVP-9279                     PIC S9(004) COMP-5 VALUE 9279*/
        public IntBasis CVP_9279 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9279);
        /*"  03  CVP-9280                     PIC S9(004) COMP-5 VALUE 9280*/
        public IntBasis CVP_9280 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9280);
        /*"  03  CVP-9281                     PIC S9(004) COMP-5 VALUE 9281*/
        public IntBasis CVP_9281 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9281);
        /*"  03  CVP-9282                     PIC S9(004) COMP-5 VALUE 9282*/
        public IntBasis CVP_9282 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9282);
        /*"  03  CVP-9283                     PIC S9(004) COMP-5 VALUE 9283*/
        public IntBasis CVP_9283 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9283);
        /*"  03  CVP-9284                     PIC S9(004) COMP-5 VALUE 9284*/
        public IntBasis CVP_9284 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9284);
        /*"  03  CVP-9285                     PIC S9(004) COMP-5 VALUE 9285*/
        public IntBasis CVP_9285 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9285);
        /*"  03  CVP-9286                     PIC S9(004) COMP-5 VALUE 9286*/
        public IntBasis CVP_9286 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9286);
        /*"  03  CVP-9287                     PIC S9(004) COMP-5 VALUE 9287*/
        public IntBasis CVP_9287 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9287);
        /*"  03  CVP-9288                     PIC S9(004) COMP-5 VALUE 9288*/
        public IntBasis CVP_9288 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9288);
        /*"  03  CVP-9289                     PIC S9(004) COMP-5 VALUE 9289*/
        public IntBasis CVP_9289 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9289);
        /*"  03  CVP-9290                     PIC S9(004) COMP-5 VALUE 9290*/
        public IntBasis CVP_9290 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9290);
        /*"  03  CVP-9291                     PIC S9(004) COMP-5 VALUE 9291*/
        public IntBasis CVP_9291 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9291);
        /*"  03  CVP-9292                     PIC S9(004) COMP-5 VALUE 9292*/
        public IntBasis CVP_9292 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9292);
        /*"  03  CVP-9293                     PIC S9(004) COMP-5 VALUE 9293*/
        public IntBasis CVP_9293 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9293);
        /*"  03  CVP-9299                     PIC S9(004) COMP-5 VALUE 9299*/
        public IntBasis CVP_9299 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9299);
        /*"  03  CVP-9300                     PIC S9(004) COMP-5 VALUE 9300*/
        public IntBasis CVP_9300 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9300);
        /*"  03  CVP-9301                     PIC S9(004) COMP-5 VALUE 9301*/
        public IntBasis CVP_9301 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9301);
        /*"  03  CVP-9302                     PIC S9(004) COMP-5 VALUE 9302*/
        public IntBasis CVP_9302 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9302);
        /*"  03  CVP-9303                     PIC S9(004) COMP-5 VALUE 9303*/
        public IntBasis CVP_9303 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9303);
        /*"  03  CVP-9304                     PIC S9(004) COMP-5 VALUE 9304*/
        public IntBasis CVP_9304 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9304);
        /*"  03  CVP-9305                     PIC S9(004) COMP-5 VALUE 9305*/
        public IntBasis CVP_9305 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9305);
        /*"  03  CVP-9306                     PIC S9(004) COMP-5 VALUE 9306*/
        public IntBasis CVP_9306 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9306);
        /*"  03  CVP-9307                     PIC S9(004) COMP-5 VALUE 9307*/
        public IntBasis CVP_9307 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9307);
        /*"  03  CVP-9308                     PIC S9(004) COMP-5 VALUE 9308*/
        public IntBasis CVP_9308 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9308);
        /*"  03  CVP-9309                     PIC S9(004) COMP-5 VALUE 9309*/
        public IntBasis CVP_9309 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9309);
        /*"  03  CVP-9310                     PIC S9(004) COMP-5 VALUE 9310*/
        public IntBasis CVP_9310 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9310);
        /*"  03  CVP-9311                     PIC S9(004) COMP-5 VALUE 9311*/
        public IntBasis CVP_9311 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9311);
        /*"  03  CVP-9312                     PIC S9(004) COMP-5 VALUE 9312*/
        public IntBasis CVP_9312 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9312);
        /*"  03  CVP-9313                     PIC S9(004) COMP-5 VALUE 9313*/
        public IntBasis CVP_9313 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9313);
        /*"  03  CVP-9314                     PIC S9(004) COMP-5 VALUE 9314*/
        public IntBasis CVP_9314 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9314);
        /*"  03  CVP-9315                     PIC S9(004) COMP-5 VALUE 9315*/
        public IntBasis CVP_9315 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9315);
        /*"  03  CVP-9316                     PIC S9(004) COMP-5 VALUE 9316*/
        public IntBasis CVP_9316 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9316);
        /*"  03  CVP-9317                     PIC S9(004) COMP-5 VALUE 9317*/
        public IntBasis CVP_9317 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9317);
        /*"  03  CVP-9318                     PIC S9(004) COMP-5 VALUE 9318*/
        public IntBasis CVP_9318 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9318);
        /*"  03  CVP-9319                     PIC S9(004) COMP-5 VALUE 9319*/
        public IntBasis CVP_9319 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9319);
        /*"  03  CVP-9320                     PIC S9(004) COMP-5 VALUE 9320*/
        public IntBasis CVP_9320 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9320);
        /*"  03  CVP-9321                     PIC S9(004) COMP-5 VALUE 9321*/
        public IntBasis CVP_9321 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9321);
        /*"  03  CVP-9322                     PIC S9(004) COMP-5 VALUE 9322*/
        public IntBasis CVP_9322 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9322);
        /*"  03  CVP-9323                     PIC S9(004) COMP-5 VALUE 9323*/
        public IntBasis CVP_9323 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9323);
        /*"  03  CVP-9324                     PIC S9(004) COMP-5 VALUE 9324*/
        public IntBasis CVP_9324 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9324);
        /*"  03  CVP-9325                     PIC S9(004) COMP-5 VALUE 9325*/
        public IntBasis CVP_9325 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9325);
        /*"  03  CVP-9326                     PIC S9(004) COMP-5 VALUE 9326*/
        public IntBasis CVP_9326 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9326);
        /*"  03  CVP-9327                     PIC S9(004) COMP-5 VALUE 9327*/
        public IntBasis CVP_9327 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9327);
        /*"  03  CVP-9328                     PIC S9(004) COMP-5 VALUE 9328*/
        public IntBasis CVP_9328 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9328);
        /*"  03  CVP-9329                     PIC S9(004) COMP-5 VALUE 9329*/
        public IntBasis CVP_9329 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9329);
        /*"  03  CVP-9330                     PIC S9(004) COMP-5 VALUE 9330*/
        public IntBasis CVP_9330 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9330);
        /*"  03  CVP-9331                     PIC S9(004) COMP-5 VALUE 9331*/
        public IntBasis CVP_9331 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9331);
        /*"  03  CVP-9332                     PIC S9(004) COMP-5 VALUE 9332*/
        public IntBasis CVP_9332 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9332);
        /*"  03  CVP-9333                     PIC S9(004) COMP-5 VALUE 9333*/
        public IntBasis CVP_9333 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9333);
        /*"  03  CVP-9334                     PIC S9(004) COMP-5 VALUE 9334*/
        public IntBasis CVP_9334 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9334);
        /*"  03  CVP-9335                     PIC S9(004) COMP-5 VALUE 9335*/
        public IntBasis CVP_9335 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9335);
        /*"  03  CVP-9336                     PIC S9(004) COMP-5 VALUE 9336*/
        public IntBasis CVP_9336 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9336);
        /*"  03  CVP-9337                     PIC S9(004) COMP-5 VALUE 9337*/
        public IntBasis CVP_9337 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9337);
        /*"  03  CVP-9338                     PIC S9(004) COMP-5 VALUE 9338*/
        public IntBasis CVP_9338 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9338);
        /*"  03  CVP-9339                     PIC S9(004) COMP-5 VALUE 9339*/
        public IntBasis CVP_9339 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9339);
        /*"  03  CVP-9340                     PIC S9(004) COMP-5 VALUE 9340*/
        public IntBasis CVP_9340 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9340);
        /*"  03  CVP-9341                     PIC S9(004) COMP-5 VALUE 9341*/
        public IntBasis CVP_9341 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9341);
        /*"  03  CVP-9342                     PIC S9(004) COMP-5 VALUE 9342*/
        public IntBasis CVP_9342 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9342);
        /*"  03  CVP-9343                     PIC S9(004) COMP-5 VALUE 9343*/
        public IntBasis CVP_9343 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9343);
        /*"  03  CVP-9344                     PIC S9(004) COMP-5 VALUE 9344*/
        public IntBasis CVP_9344 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9344);
        /*"  03  CVP-9345                     PIC S9(004) COMP-5 VALUE 9345*/
        public IntBasis CVP_9345 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9345);
        /*"  03  CVP-9346                     PIC S9(004) COMP-5 VALUE 9346*/
        public IntBasis CVP_9346 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9346);
        /*"  03  CVP-9347                     PIC S9(004) COMP-5 VALUE 9347*/
        public IntBasis CVP_9347 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9347);
        /*"  03  CVP-9348                     PIC S9(004) COMP-5 VALUE 9348*/
        public IntBasis CVP_9348 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9348);
        /*"  03  CVP-9349                     PIC S9(004) COMP-5 VALUE 9349*/
        public IntBasis CVP_9349 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9349);
        /*"  03  CVP-9350                     PIC S9(004) COMP-5 VALUE 9350*/
        public IntBasis CVP_9350 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9350);
        /*"  03  CVP-9351                     PIC S9(004) COMP-5 VALUE 9351*/
        public IntBasis CVP_9351 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9351);
        /*"  03  CVP-9352                     PIC S9(004) COMP-5 VALUE 9352*/
        public IntBasis CVP_9352 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9352);
        /*"  03  CVP-9353                     PIC S9(004) COMP-5 VALUE 9353*/
        public IntBasis CVP_9353 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9353);
        /*"  03  CVP-9355                     PIC S9(004) COMP-5 VALUE 9355*/
        public IntBasis CVP_9355 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9355);
        /*"  03  CVP-9356                     PIC S9(004) COMP-5 VALUE 9356*/
        public IntBasis CVP_9356 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9356);
        /*"  03  CVP-9357                     PIC S9(004) COMP-5 VALUE 9357*/
        public IntBasis CVP_9357 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9357);
        /*"  03  CVP-9358                     PIC S9(004) COMP-5 VALUE 9358*/
        public IntBasis CVP_9358 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9358);
        /*"  03  CVP-9359                     PIC S9(004) COMP-5 VALUE 9359*/
        public IntBasis CVP_9359 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9359);
        /*"  03  CVP-9360                     PIC S9(004) COMP-5 VALUE 9360*/
        public IntBasis CVP_9360 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9360);
        /*"  03  CVP-9361                     PIC S9(004) COMP-5 VALUE 9361*/
        public IntBasis CVP_9361 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9361);
        /*"  03  CVP-9362                     PIC S9(004) COMP-5 VALUE 9362*/
        public IntBasis CVP_9362 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9362);
        /*"  03  CVP-9363                     PIC S9(004) COMP-5 VALUE 9363*/
        public IntBasis CVP_9363 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9363);
        /*"  03  CVP-9364                     PIC S9(004) COMP-5 VALUE 9364*/
        public IntBasis CVP_9364 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9364);
        /*"  03  CVP-9365                     PIC S9(004) COMP-5 VALUE 9365*/
        public IntBasis CVP_9365 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9365);
        /*"  03  CVP-9366                     PIC S9(004) COMP-5 VALUE 9366*/
        public IntBasis CVP_9366 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9366);
        /*"  03  CVP-9367                     PIC S9(004) COMP-5 VALUE 9367*/
        public IntBasis CVP_9367 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9367);
        /*"  03  CVP-9368                     PIC S9(004) COMP-5 VALUE 9368*/
        public IntBasis CVP_9368 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9368);
        /*"  03  CVP-9369                     PIC S9(004) COMP-5 VALUE 9369*/
        public IntBasis CVP_9369 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9369);
        /*"  03  CVP-9370                     PIC S9(004) COMP-5 VALUE 9370*/
        public IntBasis CVP_9370 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9370);
        /*"  03  CVP-9371                     PIC S9(004) COMP-5 VALUE 9371*/
        public IntBasis CVP_9371 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9371);
        /*"  03  CVP-9372                     PIC S9(004) COMP-5 VALUE 9372*/
        public IntBasis CVP_9372 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9372);
        /*"  03  CVP-9373                     PIC S9(004) COMP-5 VALUE 9373*/
        public IntBasis CVP_9373 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9373);
        /*"  03  CVP-9388                     PIC S9(004) COMP-5 VALUE 9388*/
        public IntBasis CVP_9388 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9388);
        /*"  03  CVP-9389                     PIC S9(004) COMP-5 VALUE 9389*/
        public IntBasis CVP_9389 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9389);
        /*"  03  CVP-9390                     PIC S9(004) COMP-5 VALUE 9390*/
        public IntBasis CVP_9390 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9390);
        /*"  03  CVP-9391                     PIC S9(004) COMP-5 VALUE 9391*/
        public IntBasis CVP_9391 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9391);
        /*"  03  CVP-9399                     PIC S9(004) COMP-5 VALUE 9399*/
        public IntBasis CVP_9399 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9399);
        /*"  03  CVP-9401                     PIC S9(004) COMP-5 VALUE 9401*/
        public IntBasis CVP_9401 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9401);
        /*"  03  CVP-9402                     PIC S9(004) COMP-5 VALUE 9402*/
        public IntBasis CVP_9402 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9402);
        /*"  03  CVP-9403                     PIC S9(004) COMP-5 VALUE 9403*/
        public IntBasis CVP_9403 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9403);
        /*"  03  CVP-9404                     PIC S9(004) COMP-5 VALUE 9404*/
        public IntBasis CVP_9404 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9404);
        /*"  03  CVP-9405                     PIC S9(004) COMP-5 VALUE 9405*/
        public IntBasis CVP_9405 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9405);
        /*"  03  CVP-9406                     PIC S9(004) COMP-5 VALUE 9406*/
        public IntBasis CVP_9406 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9406);
        /*"  03  CVP-9407                     PIC S9(004) COMP-5 VALUE 9407*/
        public IntBasis CVP_9407 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9407);
        /*"  03  CVP-9408                     PIC S9(004) COMP-5 VALUE 9408*/
        public IntBasis CVP_9408 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9408);
        /*"  03  CVP-9409                     PIC S9(004) COMP-5 VALUE 9409*/
        public IntBasis CVP_9409 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9409);
        /*"  03  CVP-9410                     PIC S9(004) COMP-5 VALUE 9410*/
        public IntBasis CVP_9410 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9410);
        /*"  03  CVP-9411                     PIC S9(004) COMP-5 VALUE 9411*/
        public IntBasis CVP_9411 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9411);
        /*"  03  CVP-9412                     PIC S9(004) COMP-5 VALUE 9412*/
        public IntBasis CVP_9412 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9412);
        /*"  03  CVP-9413                     PIC S9(004) COMP-5 VALUE 9413*/
        public IntBasis CVP_9413 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9413);
        /*"  03  CVP-9414                     PIC S9(004) COMP-5 VALUE 9414*/
        public IntBasis CVP_9414 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9414);
        /*"  03  CVP-9415                     PIC S9(004) COMP-5 VALUE 9415*/
        public IntBasis CVP_9415 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9415);
        /*"  03  CVP-9416                     PIC S9(004) COMP-5 VALUE 9416*/
        public IntBasis CVP_9416 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9416);
        /*"  03  CVP-9417                     PIC S9(004) COMP-5 VALUE 9417*/
        public IntBasis CVP_9417 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9417);
        /*"  03  CVP-9418                     PIC S9(004) COMP-5 VALUE 9418*/
        public IntBasis CVP_9418 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9418);
        /*"  03  CVP-9419                     PIC S9(004) COMP-5 VALUE 9419*/
        public IntBasis CVP_9419 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9419);
        /*"  03  CVP-9420                     PIC S9(004) COMP-5 VALUE 9420*/
        public IntBasis CVP_9420 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9420);
        /*"  03  CVP-9421                     PIC S9(004) COMP-5 VALUE 9421*/
        public IntBasis CVP_9421 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9421);
        /*"  03  CVP-9422                     PIC S9(004) COMP-5 VALUE 9422*/
        public IntBasis CVP_9422 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9422);
        /*"  03  CVP-9423                     PIC S9(004) COMP-5 VALUE 9423*/
        public IntBasis CVP_9423 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9423);
        /*"  03  CVP-9424                     PIC S9(004) COMP-5 VALUE 9424*/
        public IntBasis CVP_9424 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9424);
        /*"  03  CVP-9425                     PIC S9(004) COMP-5 VALUE 9425*/
        public IntBasis CVP_9425 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9425);
        /*"  03  CVP-9426                     PIC S9(004) COMP-5 VALUE 9426*/
        public IntBasis CVP_9426 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9426);
        /*"  03  CVP-9427                     PIC S9(004) COMP-5 VALUE 9427*/
        public IntBasis CVP_9427 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9427);
        /*"  03  CVP-9428                     PIC S9(004) COMP-5 VALUE 9428*/
        public IntBasis CVP_9428 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9428);
        /*"  03  CVP-9429                     PIC S9(004) COMP-5 VALUE 9429*/
        public IntBasis CVP_9429 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9429);
        /*"  03  CVP-9430                     PIC S9(004) COMP-5 VALUE 9430*/
        public IntBasis CVP_9430 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9430);
        /*"  03  CVP-9431                     PIC S9(004) COMP-5 VALUE 9431*/
        public IntBasis CVP_9431 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9431);
        /*"  03  CVP-9432                     PIC S9(004) COMP-5 VALUE 9432*/
        public IntBasis CVP_9432 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9432);
        /*"  03  CVP-9433                     PIC S9(004) COMP-5 VALUE 9433*/
        public IntBasis CVP_9433 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9433);
        /*"  03  CVP-9434                     PIC S9(004) COMP-5 VALUE 9434*/
        public IntBasis CVP_9434 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9434);
        /*"  03  CVP-9435                     PIC S9(004) COMP-5 VALUE 9435*/
        public IntBasis CVP_9435 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9435);
        /*"  03  CVP-9436                     PIC S9(004) COMP-5 VALUE 9436*/
        public IntBasis CVP_9436 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9436);
        /*"  03  CVP-9437                     PIC S9(004) COMP-5 VALUE 9437*/
        public IntBasis CVP_9437 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9437);
        /*"  03  CVP-9438                     PIC S9(004) COMP-5 VALUE 9438*/
        public IntBasis CVP_9438 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9438);
        /*"  03  CVP-9439                     PIC S9(004) COMP-5 VALUE 9439*/
        public IntBasis CVP_9439 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9439);
        /*"  03  CVP-9440                     PIC S9(004) COMP-5 VALUE 9440*/
        public IntBasis CVP_9440 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9440);
        /*"  03  CVP-9441                     PIC S9(004) COMP-5 VALUE 9441*/
        public IntBasis CVP_9441 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9441);
        /*"  03  CVP-9442                     PIC S9(004) COMP-5 VALUE 9442*/
        public IntBasis CVP_9442 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9442);
        /*"  03  CVP-9443                     PIC S9(004) COMP-5 VALUE 9443*/
        public IntBasis CVP_9443 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9443);
        /*"  03  CVP-9444                     PIC S9(004) COMP-5 VALUE 9444*/
        public IntBasis CVP_9444 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9444);
        /*"  03  CVP-9445                     PIC S9(004) COMP-5 VALUE 9445*/
        public IntBasis CVP_9445 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9445);
        /*"  03  CVP-9446                     PIC S9(004) COMP-5 VALUE 9446*/
        public IntBasis CVP_9446 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9446);
        /*"  03  CVP-9447                     PIC S9(004) COMP-5 VALUE 9447*/
        public IntBasis CVP_9447 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9447);
        /*"  03  CVP-9448                     PIC S9(004) COMP-5 VALUE 9448*/
        public IntBasis CVP_9448 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9448);
        /*"  03  CVP-9449                     PIC S9(004) COMP-5 VALUE 9449*/
        public IntBasis CVP_9449 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9449);
        /*"  03  CVP-9450                     PIC S9(004) COMP-5 VALUE 9450*/
        public IntBasis CVP_9450 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9450);
        /*"  03  CVP-9451                     PIC S9(004) COMP-5 VALUE 9451*/
        public IntBasis CVP_9451 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9451);
        /*"  03  CVP-9452                     PIC S9(004) COMP-5 VALUE 9452*/
        public IntBasis CVP_9452 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9452);
        /*"  03  CVP-9499                     PIC S9(004) COMP-5 VALUE 9499*/
        public IntBasis CVP_9499 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9499);
        /*"  03  CVP-9701                     PIC S9(004) COMP-5 VALUE 9701*/
        public IntBasis CVP_9701 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9701);
        /*"  03  CVP-9702                     PIC S9(004) COMP-5 VALUE 9702*/
        public IntBasis CVP_9702 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9702);
        /*"  03  CVP-9703                     PIC S9(004) COMP-5 VALUE 9703*/
        public IntBasis CVP_9703 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9703);
        /*"  03  CVP-9704                     PIC S9(004) COMP-5 VALUE 9704*/
        public IntBasis CVP_9704 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9704);
        /*"  03  CVP-9705                     PIC S9(004) COMP-5 VALUE 9705*/
        public IntBasis CVP_9705 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9705);
        /*"  03  CVP-9706                     PIC S9(004) COMP-5 VALUE 9706*/
        public IntBasis CVP_9706 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9706);
        /*"  03  CVP-9707                     PIC S9(004) COMP-5 VALUE 9707*/
        public IntBasis CVP_9707 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9707);
        /*"  03  CVP-9708                     PIC S9(004) COMP-5 VALUE 9708*/
        public IntBasis CVP_9708 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9708);
        /*"  03  CVP-9709                     PIC S9(004) COMP-5 VALUE 9709*/
        public IntBasis CVP_9709 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9709);
        /*"  03  CVP-9710                     PIC S9(004) COMP-5 VALUE 9710*/
        public IntBasis CVP_9710 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9710);
        /*"  03  CVP-9711                     PIC S9(004) COMP-5 VALUE 9711*/
        public IntBasis CVP_9711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9711);
        /*"  03  CVP-9712                     PIC S9(004) COMP-5 VALUE 9712*/
        public IntBasis CVP_9712 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9712);
        /*"  03  CVP-9713                     PIC S9(004) COMP-5 VALUE 9713*/
        public IntBasis CVP_9713 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9713);
        /*"  03  CVP-9714                     PIC S9(004) COMP-5 VALUE 9714*/
        public IntBasis CVP_9714 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9714);
        /*"  03  CVP-9715                     PIC S9(004) COMP-5 VALUE 9715*/
        public IntBasis CVP_9715 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9715);
        /*"  03  CVP-9788                     PIC S9(004) COMP-5 VALUE 9788*/
        public IntBasis CVP_9788 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9788);
        /*"  03  CVP-9789                     PIC S9(004) COMP-5 VALUE 9789*/
        public IntBasis CVP_9789 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9789);
        /*"  03  CVP-9799                     PIC S9(004) COMP-5 VALUE 9799*/
        public IntBasis CVP_9799 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9799);
        /*"  03  CVP-9801                     PIC S9(004) COMP-5 VALUE 9801*/
        public IntBasis CVP_9801 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9801);
        /*"  03  CVP-9802                     PIC S9(004) COMP-5 VALUE 9802*/
        public IntBasis CVP_9802 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9802);
        /*"  03  CVP-9888                     PIC S9(004) COMP-5 VALUE 9888*/
        public IntBasis CVP_9888 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9888);
        /*"  03  CVP-9889                     PIC S9(004) COMP-5 VALUE 9889*/
        public IntBasis CVP_9889 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9889);
        /*"01    CVP-PRODUTO      REDEFINES   CVP-PRODUTOS-RUNOFF*/
    }
}