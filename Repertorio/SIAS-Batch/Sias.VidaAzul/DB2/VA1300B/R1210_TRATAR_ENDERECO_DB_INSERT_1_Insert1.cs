using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO ODS.OD_PESSOA_ENDERECO VALUES
            ( :OD007-NUM-PESSOA
            ,:OD007-SEQ-ENDERECO
            , CURRENT TIMESTAMP
            ,:OD007-IND-ENDERECO
            ,:OD007-STA-ENDERECO
            ,:OD007-NOM-LOGRADOURO
            ,:OD007-DES-NUM-IMOVEL
            ,:OD007-DES-COMPL-ENDERECO
            ,:OD007-NOM-BAIRRO
            ,:OD007-NOM-CIDADE
            ,:OD007-COD-CEP
            ,:OD007-COD-UF
            ,:OD007-STA-CORRESPONDER
            ,:OD007-STA-PROPAGANDA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESSOA_ENDERECO VALUES ( {FieldThreatment(this.OD007_NUM_PESSOA)} ,{FieldThreatment(this.OD007_SEQ_ENDERECO)} , CURRENT TIMESTAMP ,{FieldThreatment(this.OD007_IND_ENDERECO)} ,{FieldThreatment(this.OD007_STA_ENDERECO)} ,{FieldThreatment(this.OD007_NOM_LOGRADOURO)} ,{FieldThreatment(this.OD007_DES_NUM_IMOVEL)} ,{FieldThreatment(this.OD007_DES_COMPL_ENDERECO)} ,{FieldThreatment(this.OD007_NOM_BAIRRO)} ,{FieldThreatment(this.OD007_NOM_CIDADE)} ,{FieldThreatment(this.OD007_COD_CEP)} ,{FieldThreatment(this.OD007_COD_UF)} ,{FieldThreatment(this.OD007_STA_CORRESPONDER)} ,{FieldThreatment(this.OD007_STA_PROPAGANDA)} )";

            return query;
        }
        public string OD007_NUM_PESSOA { get; set; }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_IND_ENDERECO { get; set; }
        public string OD007_STA_ENDERECO { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string OD007_COD_UF { get; set; }
        public string OD007_STA_CORRESPONDER { get; set; }
        public string OD007_STA_PROPAGANDA { get; set; }

        public static void Execute(R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1 r1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = r1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}