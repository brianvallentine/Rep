using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0),
            VALUE(SUM(T1.PREMIO_AP), 0)
            INTO :WHOST-QTDSEG,
            :PARCEVID-PREMIO-AP
            FROM SEGUROS.PARCELAS_VIDAZUL T1
            WHERE T1.SIT_REGISTRO = 'V'
            AND T1.NUM_CERTIFICADO IN
            (SELECT T10.NUM_CERTIFICADO
            FROM SEGUROS.PROPOSTAS_VA T10
            WHERE T10.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND T10.DTPROXVEN = '9999-12-31' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
							,
											VALUE(SUM(T1.PREMIO_AP)
							, 0)
											FROM SEGUROS.PARCELAS_VIDAZUL T1
											WHERE T1.SIT_REGISTRO = 'V'
											AND T1.NUM_CERTIFICADO IN
											(SELECT T10.NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA T10
											WHERE T10.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND T10.DTPROXVEN = '9999-12-31' )";

            return query;
        }
        public string WHOST_QTDSEG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1 r1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDSEG = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}