using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WS-CONT-PARC-AT
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND NUM_PARCELA >= :WS-NUM-PARCELA
            AND DATA_VENCIMENTO <= :V1SIST-DTMOVABE
            AND SIT_REGISTRO IN ( ' ' , '0' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND NUM_PARCELA >= '{this.WS_NUM_PARCELA}'
											AND DATA_VENCIMENTO <= '{this.V1SIST_DTMOVABE}'
											AND SIT_REGISTRO IN ( ' ' 
							, '0' )";

            return query;
        }
        public string WS_CONT_PARC_AT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string WS_NUM_PARCELA { get; set; }

        public static R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 Execute(R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CONT_PARC_AT = result[i++].Value?.ToString();
            return dta;
        }

    }
}