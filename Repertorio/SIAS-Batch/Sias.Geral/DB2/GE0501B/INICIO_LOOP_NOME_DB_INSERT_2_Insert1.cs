using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0501B
{
    public class INICIO_LOOP_NOME_DB_INSERT_2_Insert1 : QueryBasis<INICIO_LOOP_NOME_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO ODS.OD_PESSOA_JURIDICA
            (NUM_PESSOA ,
            NUM_CNPJ ,
            NUM_FILIAL ,
            NUM_DV_CNPJ ,
            NOM_RAZAO_SOCIAL ,
            STA_PESSOA ,
            NUM_RAMO_ATIVIDADE,
            DTH_FUNDACAO ,
            NOM_FANTASIA ,
            NOM_SIGLA_PESSOA ,
            NUM_INSC_ESTADUAL ,
            NUM_INSC_MUNICIPAL,
            COD_UF ,
            NUM_MUNICIPIO ,
            COD_CNAE ,
            NUM_SOCIOS ,
            STA_FRANQUIA ,
            IND_FINALIDADE )
            VALUES (:OD003-NUM-PESSOA ,
            :OD003-NUM-CNPJ ,
            :OD003-NUM-FILIAL ,
            :OD003-NUM-DV-CNPJ ,
            :OD003-NOM-RAZAO-SOCIAL,
            :OD003-STA-PESSOA ,
            :OD003-NUM-RAMO-ATIVIDADE:IND-NULL-01,
            :OD003-DTH-FUNDACAO:IND-NULL-02,
            :OD003-NOM-FANTASIA:IND-NULL-03,
            :OD003-NOM-SIGLA-PESSOA:IND-NULL-04,
            :OD003-NUM-INSC-ESTADUAL:IND-NULL-05,
            :OD003-NUM-INSC-MUNICIPAL:IND-NULL-06,
            :OD003-COD-UF:IND-NULL-07,
            :OD003-NUM-MUNICIPIO:IND-NULL-08,
            :OD003-COD-CNAE:IND-NULL-09,
            :OD003-NUM-SOCIOS:IND-NULL-10,
            :OD003-STA-FRANQUIA:IND-NULL-11,
            :OD003-IND-FINALIDADE:IND-NULL-12)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESSOA_JURIDICA (NUM_PESSOA , NUM_CNPJ , NUM_FILIAL , NUM_DV_CNPJ , NOM_RAZAO_SOCIAL , STA_PESSOA , NUM_RAMO_ATIVIDADE, DTH_FUNDACAO , NOM_FANTASIA , NOM_SIGLA_PESSOA , NUM_INSC_ESTADUAL , NUM_INSC_MUNICIPAL, COD_UF , NUM_MUNICIPIO , COD_CNAE , NUM_SOCIOS , STA_FRANQUIA , IND_FINALIDADE ) VALUES ({FieldThreatment(this.OD003_NUM_PESSOA)} , {FieldThreatment(this.OD003_NUM_CNPJ)} , {FieldThreatment(this.OD003_NUM_FILIAL)} , {FieldThreatment(this.OD003_NUM_DV_CNPJ)} , {FieldThreatment(this.OD003_NOM_RAZAO_SOCIAL)}, {FieldThreatment(this.OD003_STA_PESSOA)} ,  {FieldThreatment((this.IND_NULL_01?.ToInt() == -1 ? null : this.OD003_NUM_RAMO_ATIVIDADE))},  {FieldThreatment((this.IND_NULL_02?.ToInt() == -1 ? null : this.OD003_DTH_FUNDACAO))},  {FieldThreatment((this.IND_NULL_03?.ToInt() == -1 ? null : this.OD003_NOM_FANTASIA))},  {FieldThreatment((this.IND_NULL_04?.ToInt() == -1 ? null : this.OD003_NOM_SIGLA_PESSOA))},  {FieldThreatment((this.IND_NULL_05?.ToInt() == -1 ? null : this.OD003_NUM_INSC_ESTADUAL))},  {FieldThreatment((this.IND_NULL_06?.ToInt() == -1 ? null : this.OD003_NUM_INSC_MUNICIPAL))},  {FieldThreatment((this.IND_NULL_07?.ToInt() == -1 ? null : this.OD003_COD_UF))},  {FieldThreatment((this.IND_NULL_08?.ToInt() == -1 ? null : this.OD003_NUM_MUNICIPIO))},  {FieldThreatment((this.IND_NULL_09?.ToInt() == -1 ? null : this.OD003_COD_CNAE))},  {FieldThreatment((this.IND_NULL_10?.ToInt() == -1 ? null : this.OD003_NUM_SOCIOS))},  {FieldThreatment((this.IND_NULL_11?.ToInt() == -1 ? null : this.OD003_STA_FRANQUIA))},  {FieldThreatment((this.IND_NULL_12?.ToInt() == -1 ? null : this.OD003_IND_FINALIDADE))})";

            return query;
        }
        public string OD003_NUM_PESSOA { get; set; }
        public string OD003_NUM_CNPJ { get; set; }
        public string OD003_NUM_FILIAL { get; set; }
        public string OD003_NUM_DV_CNPJ { get; set; }
        public string OD003_NOM_RAZAO_SOCIAL { get; set; }
        public string OD003_STA_PESSOA { get; set; }
        public string OD003_NUM_RAMO_ATIVIDADE { get; set; }
        public string IND_NULL_01 { get; set; }
        public string OD003_DTH_FUNDACAO { get; set; }
        public string IND_NULL_02 { get; set; }
        public string OD003_NOM_FANTASIA { get; set; }
        public string IND_NULL_03 { get; set; }
        public string OD003_NOM_SIGLA_PESSOA { get; set; }
        public string IND_NULL_04 { get; set; }
        public string OD003_NUM_INSC_ESTADUAL { get; set; }
        public string IND_NULL_05 { get; set; }
        public string OD003_NUM_INSC_MUNICIPAL { get; set; }
        public string IND_NULL_06 { get; set; }
        public string OD003_COD_UF { get; set; }
        public string IND_NULL_07 { get; set; }
        public string OD003_NUM_MUNICIPIO { get; set; }
        public string IND_NULL_08 { get; set; }
        public string OD003_COD_CNAE { get; set; }
        public string IND_NULL_09 { get; set; }
        public string OD003_NUM_SOCIOS { get; set; }
        public string IND_NULL_10 { get; set; }
        public string OD003_STA_FRANQUIA { get; set; }
        public string IND_NULL_11 { get; set; }
        public string OD003_IND_FINALIDADE { get; set; }
        public string IND_NULL_12 { get; set; }

        public static void Execute(INICIO_LOOP_NOME_DB_INSERT_2_Insert1 iNICIO_LOOP_NOME_DB_INSERT_2_Insert1)
        {
            var ths = iNICIO_LOOP_NOME_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override INICIO_LOOP_NOME_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}