using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8020B
{
    public class R1200_00_SELECT_OD007_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_OD007_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PESSOA ,
            SEQ_ENDERECO ,
            NOM_LOGRADOURO ,
            DES_NUM_IMOVEL ,
            DES_COMPL_ENDERECO ,
            NOM_BAIRRO ,
            NOM_CIDADE ,
            COD_CEP ,
            COD_UF
            INTO :OD007-NUM-PESSOA ,
            :OD007-SEQ-ENDERECO ,
            :OD007-NOM-LOGRADOURO ,
            :OD007-DES-NUM-IMOVEL ,
            :OD007-DES-COMPL-ENDERECO ,
            :OD007-NOM-BAIRRO ,
            :OD007-NOM-CIDADE ,
            :OD007-COD-CEP ,
            :OD007-COD-UF
            FROM ODS.OD_PESSOA_ENDERECO
            WHERE NUM_PESSOA = :GE368-NUM-PESSOA
            AND SEQ_ENDERECO = :GE368-SEQ-ENTIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PESSOA 
							,
											SEQ_ENDERECO 
							,
											NOM_LOGRADOURO 
							,
											DES_NUM_IMOVEL 
							,
											DES_COMPL_ENDERECO 
							,
											NOM_BAIRRO 
							,
											NOM_CIDADE 
							,
											COD_CEP 
							,
											COD_UF
											FROM ODS.OD_PESSOA_ENDERECO
											WHERE NUM_PESSOA = '{this.GE368_NUM_PESSOA}'
											AND SEQ_ENDERECO = '{this.GE368_SEQ_ENTIDADE}'";

            return query;
        }
        public string OD007_NUM_PESSOA { get; set; }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string OD007_COD_UF { get; set; }
        public string GE368_SEQ_ENTIDADE { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R1200_00_SELECT_OD007_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_OD007_DB_SELECT_1_Query1 r1200_00_SELECT_OD007_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_OD007_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_OD007_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_OD007_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD007_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD007_SEQ_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.OD007_DES_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.OD007_DES_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.OD007_NOM_CIDADE = result[i++].Value?.ToString();
            dta.OD007_COD_CEP = result[i++].Value?.ToString();
            dta.OD007_COD_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}