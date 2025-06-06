using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1 : QueryBasis<R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RELATORIO
            INTO :RELATORI-COD-RELATORIO
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :VGCOMTRO-NUM-PROPOSTA-SIVPF
            AND COD_RELATORIO IN ( 'NAOEMICR' , 'NAOEMISR' )
            AND SIT_REGISTRO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_RELATORIO
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'
											AND COD_RELATORIO IN ( 'NAOEMICR' 
							, 'NAOEMISR' )
											AND SIT_REGISTRO = '1'
											WITH UR";

            return query;
        }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }

        public static R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1 Execute(R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1 r2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1)
        {
            var ths = r2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2360_2610_SELECT_RELATORI_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}