using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1 : QueryBasis<R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_FONTE,
            ORGAO_EMISSOR,
            IFNULL(ULT_PROP_AUTOMAT, 0) + :WH-QTD-ULT-PROP
            INTO :FONTES-TIPO-FONTE,
            :FONTES-ORGAO-EMISSOR,
            :FONTES-ULT-PROP-AUTOMAT
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :FONTES-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_FONTE
							,
											ORGAO_EMISSOR
							,
											IFNULL(ULT_PROP_AUTOMAT
							, 0) + '{this.WH_QTD_ULT_PROP}'
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.FONTES_COD_FONTE}'";

            return query;
        }
        public string FONTES_TIPO_FONTE { get; set; }
        public string FONTES_ORGAO_EMISSOR { get; set; }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string FONTES_COD_FONTE { get; set; }
        public string WH_QTD_ULT_PROP { get; set; }

        public static R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1 Execute(R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1 r8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_TIPO_FONTE = result[i++].Value?.ToString();
            dta.FONTES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}