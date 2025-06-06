using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1 : QueryBasis<R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_OCORR_MOVTO
            INTO :CB041-NUM-OCORR-MOVTO
            FROM SEGUROS.CB_PESS_PARCELA A
            WHERE A.NUM_APOLICE = :CB041-NUM-APOLICE
            AND A.NUM_ENDOSSO = :CB041-NUM-ENDOSSO
            AND A.NUM_PARCELA = :CB041-NUM-PARCELA
            AND A.NUM_OCORR_MOVTO =
            ( SELECT MAX(B.NUM_OCORR_MOVTO)
            FROM SEGUROS.CB_PESS_PARCELA B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_OCORR_MOVTO
											FROM SEGUROS.CB_PESS_PARCELA A
											WHERE A.NUM_APOLICE = '{this.CB041_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.CB041_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.CB041_NUM_PARCELA}'
											AND A.NUM_OCORR_MOVTO =
											( SELECT MAX(B.NUM_OCORR_MOVTO)
											FROM SEGUROS.CB_PESS_PARCELA B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA )";

            return query;
        }
        public string CB041_NUM_OCORR_MOVTO { get; set; }
        public string CB041_NUM_APOLICE { get; set; }
        public string CB041_NUM_ENDOSSO { get; set; }
        public string CB041_NUM_PARCELA { get; set; }

        public static R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1 Execute(R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1 r2100_00_VERIFICA_CB041_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_VERIFICA_CB041_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1();
            var i = 0;
            dta.CB041_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}