using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_MSG_CRITICA
            INTO :W-COD-OPERACAO
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> '3'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_MSG_CRITICA
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.ERRPROVI_NUM_CERTIFICADO}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> '3'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string W_COD_OPERACAO { get; set; }
        public string ERRPROVI_NUM_CERTIFICADO { get; set; }

        public static R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1 Execute(R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1 r0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}