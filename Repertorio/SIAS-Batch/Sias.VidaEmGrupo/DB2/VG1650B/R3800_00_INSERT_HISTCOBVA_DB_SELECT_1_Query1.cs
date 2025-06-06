using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            NUM_TITULO
            INTO :COBHISVI-NUM-CERTIFICADO,
            :COBHISVI-NUM-TITULO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :COBHISVI-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											NUM_TITULO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.COBHISVI_NUM_PARCELA}'";

            return query;
        }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }

        public static R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 Execute(R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 r3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}