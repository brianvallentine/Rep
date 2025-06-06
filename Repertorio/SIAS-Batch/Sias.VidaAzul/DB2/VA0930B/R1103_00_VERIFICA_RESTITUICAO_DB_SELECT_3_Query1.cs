using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1 : QueryBasis<R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :COBHISVI-SIT-REGISTRO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1 Execute(R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1 r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1)
        {
            var ths = r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1();
            var i = 0;
            dta.COBHISVI_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}