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
    public class LBWPF002 : VarBasis
    {
        /*"    05 W-PRODUTO                      PIC  9(004) VALUE ZEROS*/

        public SelectorBasis W_PRODUTO { get; set; } = new SelectorBasis("004", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 MULTIPREMIADO                           VALUE 01 */
							new SelectorItemBasis("MULTIPREMIADO", "01"),
							/*" 88 FEDERALPREV                             VALUE 02 */
							new SelectorItemBasis("FEDERALPREV", "02"),
							/*" 88 FEDERALPREV-PGBL                        VALUE 03 */
							new SelectorItemBasis("FEDERALPREV_PGBL", "03"),
							/*" 88 EXECUTIVO                               VALUE 04 */
							new SelectorItemBasis("EXECUTIVO", "04"),
							/*" 88 FEDPREV-CRESCER                         VALUE 05 */
							new SelectorItemBasis("FEDPREV_CRESCER", "05"),
							/*" 88 SENIOR                                  VALUE 07 */
							new SelectorItemBasis("SENIOR", "07"),
							/*" 88 FEDPREV-ECONOMIARIO                     VALUE 08 */
							new SelectorItemBasis("FEDPREV_ECONOMIARIO", "08"),
							/*" 88 BILHETE-AP                              VALUE 09 */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                              VALUE 10 */
							new SelectorItemBasis("BILHETE_RD", "10"),
							/*" 88 VIDA-DA-GENTE                           VALUE 11 */
							new SelectorItemBasis("VIDA_DA_GENTE", "11"),
							/*" 88 MULTIPREMIADO-SUPER                     VALUE 13 */
							new SelectorItemBasis("MULTIPREMIADO_SUPER", "13"),
							/*" 88 VIDA-BASICO-ESSENCIAL                   VALUE 14 */
							new SelectorItemBasis("VIDA_BASICO_ESSENCIAL", "14"),
							/*" 88 VIDAZUL-EMPRESARIAL                     VALUE 15 */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL", "15"),
							/*" 88 VIDAZUL-EMPRESARIAL-SUPER               VALUE 16 */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL_SUPER", "16"),
							/*" 88 PRODUTOS-VIDA                           VALUE          01, 04, 07, 11, 13, 14, 15, 16, 46 */
							new SelectorItemBasis("PRODUTOS_VIDA", "01,04,07,11,13,14,15,16,46"),
							/*" 88 PRODUTOS-VIDA-INDIVIDUAL-93             VALUE 93 */
							new SelectorItemBasis("PRODUTOS_VIDA_INDIVIDUAL_93", "93"),
							/*" 88 PRODUTOS-VIDA-INDIVIDUAL                VALUE          01, 04, 07, 11, 13, 14, 46 */
							new SelectorItemBasis("PRODUTOS_VIDA_INDIVIDUAL", "01,04,07,11,13,14,46"),
							/*" 88 FEDERALPREV-VGBL                        VALUE 17 */
							new SelectorItemBasis("FEDERALPREV_VGBL", "17"),
							/*" 88 CAIXA-VIDA-RESGATAVEL                   VALUE 18 */
							new SelectorItemBasis("CAIXA_VIDA_RESGATAVEL", "18"),
							/*" 88 PREVINVEST-VGBL-CRESCER                 VALUE 19 */
							new SelectorItemBasis("PREVINVEST_VGBL_CRESCER", "19"),
							/*" 88 CAIXA-CONSORCIO                         VALUE 20 */
							new SelectorItemBasis("CAIXA_CONSORCIO", "20"),
							/*" 88 PREVINVEST-PGBL-CONJUGADO               VALUE 21 */
							new SelectorItemBasis("PREVINVEST_PGBL_CONJUGADO", "21"),
							/*" 88 CRESCER-PGBL-CONJUGADO                  VALUE 22 */
							new SelectorItemBasis("CRESCER_PGBL_CONJUGADO", "22"),
							/*" 88 PREVINVEST-VGBL-CONJUGADO               VALUE 23 */
							new SelectorItemBasis("PREVINVEST_VGBL_CONJUGADO", "23"),
							/*" 88 CRESCER-VGBL-CONJUGADO                  VALUE 24 */
							new SelectorItemBasis("CRESCER_VGBL_CONJUGADO", "24"),
							/*" 88 PRODUTOS-VGBL                           VALUE          17, 18, 19, 23, 24 */
							new SelectorItemBasis("PRODUTOS_VGBL", "17,18,19,23,24"),
							/*" 88 AZULCAR                                 VALUE 30 */
							new SelectorItemBasis("AZULCAR", "30"),
							/*" 88 AUTOMOVEIS-OUTROS                       VALUE 31 */
							new SelectorItemBasis("AUTOMOVEIS_OUTROS", "31"),
							/*" 88 AZULCAR-ESPECIAL                        VALUE 32 */
							new SelectorItemBasis("AZULCAR_ESPECIAL", "32"),
							/*" 88 CARRO-FORTE-ECONOMIARIO                 VALUE 33 */
							new SelectorItemBasis("CARRO_FORTE_ECONOMIARIO", "33"),
							/*" 88 AZULCAR-FROTA                           VALUE 34 */
							new SelectorItemBasis("AZULCAR_FROTA", "34"),
							/*" 88 AZULCAR-CARRO-FORTE                     VALUE 35 */
							new SelectorItemBasis("AZULCAR_CARRO_FORTE", "35"),
							/*" 88 CARRO-FORTE-CONJUGE                     VALUE 36 */
							new SelectorItemBasis("CARRO_FORTE_CONJUGE", "36"),
							/*" 88 PROTECAO-EXECUTIVA                      VALUE 37 */
							new SelectorItemBasis("PROTECAO_EXECUTIVA", "37"),
							/*" 88 CARRO-FORTE-PARENTES                    VALUE 38 */
							new SelectorItemBasis("CARRO_FORTE_PARENTES", "38"),
							/*" 88 AZULCAR-CAIXA-TRABALHADOR               VALUE 39 */
							new SelectorItemBasis("AZULCAR_CAIXA_TRABALHADOR", "39"),
							/*" 88 CARRO-FERTE-PERFIL                      VALUE 40 */
							new SelectorItemBasis("CARRO_FERTE_PERFIL", "40"),
							/*" 88 CAIXA-AUTO-PETROBRAS                    VALUE 41 */
							new SelectorItemBasis("CAIXA_AUTO_PETROBRAS", "41"),
							/*" 88 AUTO-CORRENTISTA                        VALUE 42 */
							new SelectorItemBasis("AUTO_CORRENTISTA", "42"),
							/*" 88 AUTO-NAO-CORRENTISTA                    VALUE 43 */
							new SelectorItemBasis("AUTO_NAO_CORRENTISTA", "43"),
							/*" 88 AUTO-AUTARQUIA                          VALUE 44 */
							new SelectorItemBasis("AUTO_AUTARQUIA", "44"),
							/*" 88 AUTO-CAIXA-TRABALHADOR                  VALUE 44 */
							new SelectorItemBasis("AUTO_CAIXA_TRABALHADOR", "44"),
							/*" 88 PRODUTO-AUTOMOVEL                       VALUE          30, 31, 32, 33, 34, 35, 36, 37, 38, 39,          40, 41, 42, 43, 44, 45 */
							new SelectorItemBasis("PRODUTO_AUTOMOVEL", "30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45"),
							/*" 88 PRODUTOS-AUTO-VERA-CRUZ                 VALUE          33, 36, 38, 42, 43, 44, 45 */
							new SelectorItemBasis("PRODUTOS_AUTO_VERA_CRUZ", "33,36,38,42,43,44,45"),
							/*" 88 SEGURO-VIDA-MULHER                      VALUE 46 */
							new SelectorItemBasis("SEGURO_VIDA_MULHER", "46"),
							/*" 88 MULTIRISCO-EMPRESARIAL                  VALUE 50 */
							new SelectorItemBasis("MULTIRISCO_EMPRESARIAL", "50"),
							/*" 88 VIDA-CONFORTO                           VALUE 54 */
							new SelectorItemBasis("VIDA_CONFORTO", "54"),
							/*" 88 APOIO-VIDA-MAIS-FUTURO                  VALUE 56 */
							new SelectorItemBasis("APOIO_VIDA_MAIS_FUTURO", "56"),
							/*" 88 FEDERALCAP                              VALUE 60 */
							new SelectorItemBasis("FEDERALCAP", "60"),
							/*" 88 FEDERALCAP-CX-TRAB                      VALUE 62 */
							new SelectorItemBasis("FEDERALCAP_CX_TRAB", "62"),
							/*" 88 FEDERALCAP-MULTIBENS                    VALUE 66 */
							new SelectorItemBasis("FEDERALCAP_MULTIBENS", "66"),
							/*" 88 MR-CORRENTISTA                          VALUE 71 */
							new SelectorItemBasis("MR_CORRENTISTA", "71"),
							/*" 88 MR-ECONOMIARIO                          VALUE 72 */
							new SelectorItemBasis("MR_ECONOMIARIO", "72"),
							/*" 88 PRODUTO-MULTIRISCO                      VALUE          71, 72 */
							new SelectorItemBasis("PRODUTO_MULTIRISCO", "71,72"),
							/*" 88 SEGURO-PRESTAMISTA                      VALUE 77 */
							new SelectorItemBasis("SEGURO_PRESTAMISTA", "77"),
							/*" 88 PRODUTO-CREDITO                         VALUE          77 */
							new SelectorItemBasis("PRODUTO_CREDITO", "77"),
							/*" 88 FEDPREV-PGTO-UNICO                      VALUE 80 */
							new SelectorItemBasis("FEDPREV_PGTO_UNICO", "80"),
							/*" 88 SUPERCOPACAP-EMPRESARIAL                VALUE 81 */
							new SelectorItemBasis("SUPERCOPACAP_EMPRESARIAL", "81"),
							/*" 88 ATENASCAP                               VALUE 85 */
							new SelectorItemBasis("ATENASCAP", "85"),
							/*" 88 CAPMAIS                                 VALUE 88 */
							new SelectorItemBasis("CAPMAIS", "88"),
							/*" 88 PRODUTO-VALIDO                          VALUE          01, 02, 03, 04, 05, 07, 08, 09, 10, 11, 12, 13,          14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 30,          30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42,          43, 44, 45, 46, 60, 62, 66, 71, 72, 77,          80, 81, 85, 88 */
							new SelectorItemBasis("PRODUTO_VALIDO", "01,02,03,04,05,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,30,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,60,62,66,71,72,77,80,81,85,88"),
							/*" 88 VIDA-EXCLUSIVO-AIC                      VALUE 06 */
							new SelectorItemBasis("VIDA_EXCLUSIVO_AIC", "06"),
							/*" 88 PRODUTOS-INATIVOS                       VALUE 01 */
							new SelectorItemBasis("PRODUTOS_INATIVOS", "01")
                }
        };

    }
}