using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBWCT001_PROTOCOLO_RECEBIDO : VarBasis
    {
        /*"      10  IN-SISTEMA                   PIC  X(002).*/
        public StringBasis IN_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"      10  IN-CANAL                     PIC S9(004) COMP.*/
        public IntBasis IN_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      10  IN-PV                        PIC S9(004) COMP.*/
        public IntBasis IN_PV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      10  IN-USUARIO                   PIC  X(008).*/
        public StringBasis IN_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"      10  IN-OPERACAO                  PIC S9(004) COMP.*/

        public SelectorBasis IN_OPERACAO { get; set; } = new SelectorBasis("004")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 IN-OPER-INCLUSAO          VALUE 1 */
							new SelectorItemBasis("IN_OPER_INCLUSAO", "1"),
							/*" 88 IN-OPER-ALTERACAO         VALUE 2 */
							new SelectorItemBasis("IN_OPER_ALTERACAO", "2"),
							/*" 88 IN-OPER-EXCLUSAO          VALUE 3 */
							new SelectorItemBasis("IN_OPER_EXCLUSAO", "3"),
							/*" 88 IN-OPER-CONSULTA-CODIGO   VALUE 4 */
							new SelectorItemBasis("IN_OPER_CONSULTA_CODIGO", "4"),
							/*" 88 IN-OPER-CONSULTA-NOME     VALUE 5 */
							new SelectorItemBasis("IN_OPER_CONSULTA_NOME", "5"),
							/*" 88 IN-OPER-CONSULTA-CGCCPF   VALUE 6 */
							new SelectorItemBasis("IN_OPER_CONSULTA_CGCCPF", "6"),
							/*" 88 IN-OPER-CONSULTA-OCORR    VALUE 7 */
							new SelectorItemBasis("IN_OPER_CONSULTA_OCORR", "7"),
							/*" 88 IN-OPER-LISTA-GRUPO-1     VALUE 8 */
							new SelectorItemBasis("IN_OPER_LISTA_GRUPO_1", "8"),
							/*" 88 IN-OPER-LISTA-GRUPO-2     VALUE 9 */
							new SelectorItemBasis("IN_OPER_LISTA_GRUPO_2", "9"),
							/*" 88 IN-OPER-LISTA-GRUPO-3     VALUE 10 */
							new SelectorItemBasis("IN_OPER_LISTA_GRUPO_3", "10"),
							/*" 88 IN-OPER-LISTA-GRUPO-4     VALUE 11 */
							new SelectorItemBasis("IN_OPER_LISTA_GRUPO_4", "11"),
							/*" 88 IN-OPER-CALCULA-PRM-VE    VALUE 12 */
							new SelectorItemBasis("IN_OPER_CALCULA_PRM_VE", "12"),
							/*" 88 IN-OPER-INTEGRA-BASE-VE   VALUE 13 */
							new SelectorItemBasis("IN_OPER_INTEGRA_BASE_VE", "13"),
							/*" 88 IN-OPER-VALIDA    VALUE 1 THRU 13 */
							new SelectorItemBasis("IN_OPER_VALIDA", "1 THRU 13")
                }
        };

        /*"*/
    }
}