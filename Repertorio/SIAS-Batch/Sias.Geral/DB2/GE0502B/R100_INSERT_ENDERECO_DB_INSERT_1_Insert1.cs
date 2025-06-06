using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0502B
{
    public class R100_INSERT_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<R100_INSERT_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO ODS.OD_PESSOA_ENDERECO
            ( NUM_PESSOA ,
            SEQ_ENDERECO ,
            DTH_CADASTRAMENTO ,
            IND_ENDERECO ,
            STA_ENDERECO ,
            NOM_LOGRADOURO ,
            DES_NUM_IMOVEL ,
            DES_COMPL_ENDERECO,
            NOM_BAIRRO ,
            NOM_CIDADE ,
            COD_CEP ,
            COD_UF ,
            STA_CORRESPONDER ,
            STA_PROPAGANDA )
            VALUES (:OD007-NUM-PESSOA ,
            :OD007-SEQ-ENDERECO ,
            :OD007-DTH-CADASTRAMENTO,
            :OD007-IND-ENDERECO ,
            :OD007-STA-ENDERECO ,
            :OD007-NOM-LOGRADOURO:VIND-NULL01 ,
            :OD007-DES-NUM-IMOVEL:VIND-NULL02 ,
            :OD007-DES-COMPL-ENDERECO:VIND-NULL03 ,
            :OD007-NOM-BAIRRO:VIND-NULL04 ,
            :OD007-NOM-CIDADE:VIND-NULL05 ,
            :OD007-COD-CEP:VIND-NULL06 ,
            :OD007-COD-UF:VIND-NULL07 ,
            :OD007-STA-CORRESPONDER ,
            :OD007-STA-PROPAGANDA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESSOA_ENDERECO ( NUM_PESSOA , SEQ_ENDERECO , DTH_CADASTRAMENTO , IND_ENDERECO , STA_ENDERECO , NOM_LOGRADOURO , DES_NUM_IMOVEL , DES_COMPL_ENDERECO, NOM_BAIRRO , NOM_CIDADE , COD_CEP , COD_UF , STA_CORRESPONDER , STA_PROPAGANDA ) VALUES ({FieldThreatment(this.OD007_NUM_PESSOA)} , {FieldThreatment(this.OD007_SEQ_ENDERECO)} , {FieldThreatment(this.OD007_DTH_CADASTRAMENTO)}, {FieldThreatment(this.OD007_IND_ENDERECO)} , {FieldThreatment(this.OD007_STA_ENDERECO)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.OD007_NOM_LOGRADOURO))} ,  {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.OD007_DES_NUM_IMOVEL))} ,  {FieldThreatment((this.VIND_NULL03?.ToInt() == -1 ? null : this.OD007_DES_COMPL_ENDERECO))} ,  {FieldThreatment((this.VIND_NULL04?.ToInt() == -1 ? null : this.OD007_NOM_BAIRRO))} ,  {FieldThreatment((this.VIND_NULL05?.ToInt() == -1 ? null : this.OD007_NOM_CIDADE))} ,  {FieldThreatment((this.VIND_NULL06?.ToInt() == -1 ? null : this.OD007_COD_CEP))} ,  {FieldThreatment((this.VIND_NULL07?.ToInt() == -1 ? null : this.OD007_COD_UF))} , {FieldThreatment(this.OD007_STA_CORRESPONDER)} , {FieldThreatment(this.OD007_STA_PROPAGANDA)})";

            return query;
        }
        public string OD007_NUM_PESSOA { get; set; }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_DTH_CADASTRAMENTO { get; set; }
        public string OD007_IND_ENDERECO { get; set; }
        public string OD007_STA_ENDERECO { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD007_COD_UF { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD007_STA_CORRESPONDER { get; set; }
        public string OD007_STA_PROPAGANDA { get; set; }

        public static void Execute(R100_INSERT_ENDERECO_DB_INSERT_1_Insert1 r100_INSERT_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = r100_INSERT_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R100_INSERT_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}