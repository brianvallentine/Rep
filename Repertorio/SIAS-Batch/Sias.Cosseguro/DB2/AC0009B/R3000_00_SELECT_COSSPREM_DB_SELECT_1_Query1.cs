using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1 : QueryBasis<R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO
            INTO :WHOST-OCORHIST
            FROM SEGUROS.COSSEGURO_PREMIOS
            WHERE TIPO_SEGURO = :APOLICES-TIPO-SEGURO
            AND COD_CONGENERE = :COSHISPR-COD-CONGENERE
            AND NUM_ORDEM = :ORDEMCOS-ORDEM-CEDIDO
            AND NUM_APOLICE = :COSHISPR-NUM-APOLICE
            AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO
            AND NUM_PARCELA = :COSHISPR-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
											FROM SEGUROS.COSSEGURO_PREMIOS
											WHERE TIPO_SEGURO = '{this.APOLICES_TIPO_SEGURO}'
											AND COD_CONGENERE = '{this.COSHISPR_COD_CONGENERE}'
											AND NUM_ORDEM = '{this.ORDEMCOS_ORDEM_CEDIDO}'
											AND NUM_APOLICE = '{this.COSHISPR_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.COSHISPR_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.COSHISPR_NUM_PARCELA}'";

            return query;
        }
        public string WHOST_OCORHIST { get; set; }
        public string COSHISPR_COD_CONGENERE { get; set; }
        public string ORDEMCOS_ORDEM_CEDIDO { get; set; }
        public string APOLICES_TIPO_SEGURO { get; set; }
        public string COSHISPR_NUM_APOLICE { get; set; }
        public string COSHISPR_NUM_ENDOSSO { get; set; }
        public string COSHISPR_NUM_PARCELA { get; set; }

        public static R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1 Execute(R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1 r3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1)
        {
            var ths = r3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}