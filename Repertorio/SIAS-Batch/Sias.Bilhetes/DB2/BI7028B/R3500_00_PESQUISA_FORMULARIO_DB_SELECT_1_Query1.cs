using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 : QueryBasis<R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_CORRECAO
            , NUM_APOL_LIDER
            INTO :RELATORI-TIPO-CORRECAO
            , :RELATORI-NUM-APOL-LIDER
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'VG'
            AND NUM_APOLICE = 9999999999999
            AND COD_SUBGRUPO = 9999
            AND COD_RELATORIO = :RELATORI-COD-RELATORIO
            AND COD_PLANO = :RELATORI-COD-PLANO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT TIPO_CORRECAO
											, NUM_APOL_LIDER
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'VG'
											AND NUM_APOLICE = 9999999999999
											AND COD_SUBGRUPO = 9999
											AND COD_RELATORIO = '{this.RELATORI_COD_RELATORIO}'
											AND COD_PLANO = '{this.RELATORI_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string RELATORI_TIPO_CORRECAO { get; set; }
        public string RELATORI_NUM_APOL_LIDER { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_COD_PLANO { get; set; }

        public static R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 Execute(R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 r3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1)
        {
            var ths = r3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOL_LIDER = result[i++].Value?.ToString();
            return dta;
        }

    }
}