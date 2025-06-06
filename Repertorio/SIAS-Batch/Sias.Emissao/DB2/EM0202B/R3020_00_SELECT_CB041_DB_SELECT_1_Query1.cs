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
    public class R3020_00_SELECT_CB041_DB_SELECT_1_Query1 : QueryBasis<R3020_00_SELECT_CB041_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_OCORR_MOVTO
            INTO :CB041-NUM-OCORR-MOVTO
            FROM SEGUROS.CB_PESS_PARCELA A
            WHERE A.NUM_APOLICE = :V1EDIA-NUM-APOL
            AND A.NUM_ENDOSSO = :V1EDIA-NRENDOS
            AND A.NUM_PARCELA = :V1HIST-NRPARCEL
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
											WHERE A.NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'
											AND A.NUM_ENDOSSO = '{this.V1EDIA_NRENDOS}'
											AND A.NUM_PARCELA = '{this.V1HIST_NRPARCEL}'
											AND A.NUM_OCORR_MOVTO =
											( SELECT MAX(B.NUM_OCORR_MOVTO)
											FROM SEGUROS.CB_PESS_PARCELA B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA )";

            return query;
        }
        public string CB041_NUM_OCORR_MOVTO { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }
        public string V1HIST_NRPARCEL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

        public static R3020_00_SELECT_CB041_DB_SELECT_1_Query1 Execute(R3020_00_SELECT_CB041_DB_SELECT_1_Query1 r3020_00_SELECT_CB041_DB_SELECT_1_Query1)
        {
            var ths = r3020_00_SELECT_CB041_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3020_00_SELECT_CB041_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3020_00_SELECT_CB041_DB_SELECT_1_Query1();
            var i = 0;
            dta.CB041_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}