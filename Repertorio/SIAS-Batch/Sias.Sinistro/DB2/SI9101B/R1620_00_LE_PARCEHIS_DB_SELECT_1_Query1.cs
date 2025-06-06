using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(A.DATA_MOVIMENTO),DATE( '0001-01-01' ))
            INTO :PARCEHIS-DATA-MOVIMENTO
            FROM SEGUROS.PARCELA_HISTORICO A
            WHERE A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND A.NUM_ENDOSSO = 0
            AND A.COD_OPERACAO BETWEEN 400 AND 499
            AND A.OCORR_HISTORICO =
            (SELECT MAX(B.OCORR_HISTORICO)
            FROM SEGUROS.PARCELA_HISTORICO B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA)
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(A.DATA_MOVIMENTO)
							,DATE( '0001-01-01' ))
											FROM SEGUROS.PARCELA_HISTORICO A
											WHERE A.NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = 0
											AND A.COD_OPERACAO BETWEEN 400 AND 499
											AND A.OCORR_HISTORICO =
											(SELECT MAX(B.OCORR_HISTORICO)
											FROM SEGUROS.PARCELA_HISTORICO B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA)";

            return query;
        }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1 Execute(R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1 r1620_00_LE_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r1620_00_LE_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1620_00_LE_PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}