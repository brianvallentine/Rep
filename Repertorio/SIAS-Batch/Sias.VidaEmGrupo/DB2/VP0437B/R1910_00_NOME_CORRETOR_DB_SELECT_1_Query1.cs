using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1 : QueryBasis<R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T2.REGISTRO_SUSEP, T2.NOME_PRODUTOR
            INTO :PRODUTOR-REGISTRO-SUSEP, :PRODUTOR-NOME-PRODUTOR
            FROM SEGUROS.APOLICE_CORRETOR T1,
            SEGUROS.PRODUTORES T2
            WHERE T1.NUM_APOLICE = :APOLICOR-NUM-APOLICE
            AND T1.COD_CORRETOR = T2.COD_PRODUTOR
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T2.REGISTRO_SUSEP
							, T2.NOME_PRODUTOR
											FROM SEGUROS.APOLICE_CORRETOR T1
							,
											SEGUROS.PRODUTORES T2
											WHERE T1.NUM_APOLICE = '{this.APOLICOR_NUM_APOLICE}'
											AND T1.COD_CORRETOR = T2.COD_PRODUTOR
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRODUTOR_REGISTRO_SUSEP { get; set; }
        public string PRODUTOR_NOME_PRODUTOR { get; set; }
        public string APOLICOR_NUM_APOLICE { get; set; }

        public static R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1 Execute(R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1 r1910_00_NOME_CORRETOR_DB_SELECT_1_Query1)
        {
            var ths = r1910_00_NOME_CORRETOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTOR_REGISTRO_SUSEP = result[i++].Value?.ToString();
            dta.PRODUTOR_NOME_PRODUTOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}