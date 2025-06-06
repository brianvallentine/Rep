using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0531S
{
    public class R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1 : QueryBasis<R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CPF_CNPJ
            ,SEQ_REGISTRO
            ,NUM_CERTIFICADO_EXT
            ,DTA_INCLUSAO
            ,DTH_CADASTRAMENTO
            INTO :GE615-NUM-CPF-CNPJ
            ,:GE615-SEQ-REGISTRO
            ,:GE615-NUM-CERTIFICADO-EXT
            ,:GE615-DTA-INCLUSAO
            ,:GE615-DTH-CADASTRAMENTO
            FROM SIUS.GE_PESSOA_VALIDA_LOG
            WHERE NUM_CPF_CNPJ = :GE615-NUM-CPF-CNPJ
            AND STA_REGISTRO = 2
            ORDER BY DTH_CADASTRAMENTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CPF_CNPJ
											,SEQ_REGISTRO
											,NUM_CERTIFICADO_EXT
											,DTA_INCLUSAO
											,DTH_CADASTRAMENTO
											FROM SIUS.GE_PESSOA_VALIDA_LOG
											WHERE NUM_CPF_CNPJ = '{this.GE615_NUM_CPF_CNPJ}'
											AND STA_REGISTRO = 2
											ORDER BY DTH_CADASTRAMENTO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE615_NUM_CPF_CNPJ { get; set; }
        public string GE615_SEQ_REGISTRO { get; set; }
        public string GE615_NUM_CERTIFICADO_EXT { get; set; }
        public string GE615_DTA_INCLUSAO { get; set; }
        public string GE615_DTH_CADASTRAMENTO { get; set; }

        public static R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1 Execute(R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1 r1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE615_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.GE615_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.GE615_NUM_CERTIFICADO_EXT = result[i++].Value?.ToString();
            dta.GE615_DTA_INCLUSAO = result[i++].Value?.ToString();
            dta.GE615_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}