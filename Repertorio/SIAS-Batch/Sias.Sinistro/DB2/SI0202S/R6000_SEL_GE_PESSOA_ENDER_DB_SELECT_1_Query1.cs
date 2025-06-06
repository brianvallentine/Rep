using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202S
{
    public class R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1 : QueryBasis<R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOM_LOGRADOURO || ' ' ||
            A.DES_COMPLEMENTO || ' ' ||
            A.NUM_IMOVEL
            ,A.NOM_BAIRRO
            ,A.NOM_CIDADE
            ,A.COD_UF
            ,A.NUM_CEP
            INTO :W-GEPESEND-ENDERECO
            ,:GEPESEND-NOM-BAIRRO
            ,:GEPESEND-NOM-CIDADE
            ,:GEPESEND-COD-UF
            ,:GEPESEND-NUM-CEP
            FROM SEGUROS.GE_PESSOA_ENDERECO A
            WHERE A.COD_PESSOA = :GEPESEND-COD-PESSOA
            AND A.STA_ENDERECO = 'A'
            AND A.SEQ_ENDERECO =
            (SELECT MAX(B.SEQ_ENDERECO)
            FROM SEGUROS.GE_PESSOA_ENDERECO B
            WHERE B.COD_PESSOA = :GEPESEND-COD-PESSOA
            AND B.STA_ENDERECO = 'A' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOM_LOGRADOURO || ' ' ||
											A.DES_COMPLEMENTO || ' ' ||
											A.NUM_IMOVEL
											,A.NOM_BAIRRO
											,A.NOM_CIDADE
											,A.COD_UF
											,A.NUM_CEP
											FROM SEGUROS.GE_PESSOA_ENDERECO A
											WHERE A.COD_PESSOA = '{this.GEPESEND_COD_PESSOA}'
											AND A.STA_ENDERECO = 'A'
											AND A.SEQ_ENDERECO =
											(SELECT MAX(B.SEQ_ENDERECO)
											FROM SEGUROS.GE_PESSOA_ENDERECO B
											WHERE B.COD_PESSOA = '{this.GEPESEND_COD_PESSOA}'
											AND B.STA_ENDERECO = 'A' )
											WITH UR";

            return query;
        }
        public string W_GEPESEND_ENDERECO { get; set; }
        public string GEPESEND_NOM_BAIRRO { get; set; }
        public string GEPESEND_NOM_CIDADE { get; set; }
        public string GEPESEND_COD_UF { get; set; }
        public string GEPESEND_NUM_CEP { get; set; }
        public string GEPESEND_COD_PESSOA { get; set; }

        public static R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1 Execute(R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1 r6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1)
        {
            var ths = r6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_GEPESEND_ENDERECO = result[i++].Value?.ToString();
            dta.GEPESEND_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.GEPESEND_NOM_CIDADE = result[i++].Value?.ToString();
            dta.GEPESEND_COD_UF = result[i++].Value?.ToString();
            dta.GEPESEND_NUM_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}