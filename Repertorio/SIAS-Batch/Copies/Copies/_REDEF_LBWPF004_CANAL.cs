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
    public class _REDEF_LBWPF004_CANAL : VarBasis
    {
        /*"       05 W88-CANAL-PROPOSTA                  PIC 9(001)*/

        public SelectorBasis W88_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-GRAFICA                  VALUE 0, 6 */
							new SelectorItemBasis("CANAL_VENDA_GRAFICA", "0,6"),
							/*" 88 CANAL-VENDA-CAIXA                    VALUE 1 */
							new SelectorItemBasis("CANAL_VENDA_CAIXA", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2 */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3 */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-CORREIO                  VALUE 4 */
							new SelectorItemBasis("CANAL_VENDA_CORREIO", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5 */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7 */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8 */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
        };

        /*"      05  FILLER                             PIC 9(013)*/
        public IntBasis FILLER { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));

        public _REDEF_LBWPF004_CANAL()
        {
            W88_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
            FILLER.ValueChanged += OnValueChanged;
        }

    }
}