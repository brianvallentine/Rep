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
    public class R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(T2.IMPSEGUR), 0)
            INTO :HISCOBPR-IMPSEGUR
            FROM SEGUROS.PARCELAS_VIDAZUL T1,
            SEGUROS.HIS_COBER_PROPOST T2
            WHERE T1.SIT_REGISTRO = 'V'
            AND T1.NUM_CERTIFICADO IN
            (SELECT T10.NUM_CERTIFICADO
            FROM SEGUROS.PROPOSTAS_VA T10
            WHERE T10.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND T10.DTPROXVEN = '9999-12-31' )
            AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(T2.IMPSEGUR)
							, 0)
											FROM SEGUROS.PARCELAS_VIDAZUL T1
							,
											SEGUROS.HIS_COBER_PROPOST T2
											WHERE T1.SIT_REGISTRO = 'V'
											AND T1.NUM_CERTIFICADO IN
											(SELECT T10.NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA T10
											WHERE T10.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND T10.DTPROXVEN = '9999-12-31' )
											AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO";

            return query;
        }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMPSEGUR = result[i++].Value?.ToString();
            return dta;
        }

    }
}