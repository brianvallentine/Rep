using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1 : QueryBasis<R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO,
            COD_FONTE,
            NUM_CENTRO_CUSTO,
            NUM_MATRICULA,
            NOME_USUARIO
            INTO :USUARIOS-COD-USUARIO,
            :USUARIOS-COD-FONTE,
            :USUARIOS-NUM-CENTRO-CUSTO,
            :USUARIOS-NUM-MATRICULA,
            :USUARIOS-NOME-USUARIO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :SISINACO-COD-USUARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
							,
											COD_FONTE
							,
											NUM_CENTRO_CUSTO
							,
											NUM_MATRICULA
							,
											NOME_USUARIO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.SISINACO_COD_USUARIO}'
											WITH UR";

            return query;
        }
        public string USUARIOS_COD_USUARIO { get; set; }
        public string USUARIOS_COD_FONTE { get; set; }
        public string USUARIOS_NUM_CENTRO_CUSTO { get; set; }
        public string USUARIOS_NUM_MATRICULA { get; set; }
        public string USUARIOS_NOME_USUARIO { get; set; }
        public string SISINACO_COD_USUARIO { get; set; }

        public static R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1 Execute(R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1 r4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1)
        {
            var ths = r4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_COD_USUARIO = result[i++].Value?.ToString();
            dta.USUARIOS_COD_FONTE = result[i++].Value?.ToString();
            dta.USUARIOS_NUM_CENTRO_CUSTO = result[i++].Value?.ToString();
            dta.USUARIOS_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}