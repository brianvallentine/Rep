using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 : QueryBasis<R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_MSG_CRITICA,
            SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA, ' ' ),1,40)
            INTO :ERRPROVI-COD-ERRO ,
            :ERROSVID-DESCR-ERRO
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND A.COD_MSG_CRITICA = :ERRPROVI-COD-ERRO
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_MSG_CRITICA
							,
											SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,40)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.COD_MSG_CRITICA = '{this.ERRPROVI_COD_ERRO}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA";

            return query;
        }
        public string ERRPROVI_COD_ERRO { get; set; }
        public string ERROSVID_DESCR_ERRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 Execute(R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 r2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1)
        {
            var ths = r2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERRPROVI_COD_ERRO = result[i++].Value?.ToString();
            dta.ERROSVID_DESCR_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}