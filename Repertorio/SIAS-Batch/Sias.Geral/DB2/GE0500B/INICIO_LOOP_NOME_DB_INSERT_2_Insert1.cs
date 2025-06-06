using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0500B
{
    public class INICIO_LOOP_NOME_DB_INSERT_2_Insert1 : QueryBasis<INICIO_LOOP_NOME_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO ODS.OD_PESSOA_FISICA
            (NUM_PESSOA ,
            NUM_CPF ,
            NUM_DV_CPF ,
            NOM_PESSOA ,
            DTH_NASCIMENTO ,
            STA_SEXO ,
            IND_ESTADO_CIVIL ,
            STA_PESSOA ,
            NOM_TRATAMENTO ,
            COD_UF ,
            NUM_MUNICIPIO ,
            NUM_INSC_SOCIAL ,
            NUM_DV_INSC_SOCIAL ,
            NUM_GRAU_INSTRUCAO ,
            NOM_REDUZIDO ,
            COD_CBO ,
            NOM_PRIMEIRO ,
            NOM_ULTIMO )
            VALUES (:OD002-NUM-PESSOA ,
            :OD002-NUM-CPF ,
            :OD002-NUM-DV-CPF ,
            :OD002-NOM-PESSOA ,
            :OD002-DTH-NASCIMENTO:VIND-NULL01 ,
            :OD002-STA-SEXO:VIND-NULL02 ,
            :OD002-IND-ESTADO-CIVIL:VIND-NULL03 ,
            :OD002-STA-PESSOA ,
            :OD002-NOM-TRATAMENTO:VIND-NULL04 ,
            :OD002-COD-UF:VIND-NULL05 ,
            :OD002-NUM-MUNICIPIO:VIND-NULL06 ,
            :OD002-NUM-INSC-SOCIAL:VIND-NULL07 ,
            :OD002-NUM-DV-INSC-SOCIAL:VIND-NULL08 ,
            :OD002-NUM-GRAU-INSTRUCAO:VIND-NULL09 ,
            :OD002-NOM-REDUZIDO:VIND-NULL10 ,
            :OD002-COD-CBO:VIND-NULL11 ,
            :OD002-NOM-PRIMEIRO:VIND-NULL12 ,
            :OD002-NOM-ULTIMO:VIND-NULL13)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESSOA_FISICA (NUM_PESSOA , NUM_CPF , NUM_DV_CPF , NOM_PESSOA , DTH_NASCIMENTO , STA_SEXO , IND_ESTADO_CIVIL , STA_PESSOA , NOM_TRATAMENTO , COD_UF , NUM_MUNICIPIO , NUM_INSC_SOCIAL , NUM_DV_INSC_SOCIAL , NUM_GRAU_INSTRUCAO , NOM_REDUZIDO , COD_CBO , NOM_PRIMEIRO , NOM_ULTIMO ) VALUES ({FieldThreatment(this.OD002_NUM_PESSOA)} , {FieldThreatment(this.OD002_NUM_CPF)} , {FieldThreatment(this.OD002_NUM_DV_CPF)} , {FieldThreatment(this.OD002_NOM_PESSOA)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.OD002_DTH_NASCIMENTO))} ,  {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.OD002_STA_SEXO))} ,  {FieldThreatment((this.VIND_NULL03?.ToInt() == -1 ? null : this.OD002_IND_ESTADO_CIVIL))} , {FieldThreatment(this.OD002_STA_PESSOA)} ,  {FieldThreatment((this.VIND_NULL04?.ToInt() == -1 ? null : this.OD002_NOM_TRATAMENTO))} ,  {FieldThreatment((this.VIND_NULL05?.ToInt() == -1 ? null : this.OD002_COD_UF))} ,  {FieldThreatment((this.VIND_NULL06?.ToInt() == -1 ? null : this.OD002_NUM_MUNICIPIO))} ,  {FieldThreatment((this.VIND_NULL07?.ToInt() == -1 ? null : this.OD002_NUM_INSC_SOCIAL))} ,  {FieldThreatment((this.VIND_NULL08?.ToInt() == -1 ? null : this.OD002_NUM_DV_INSC_SOCIAL))} ,  {FieldThreatment((this.VIND_NULL09?.ToInt() == -1 ? null : this.OD002_NUM_GRAU_INSTRUCAO))} ,  {FieldThreatment((this.VIND_NULL10?.ToInt() == -1 ? null : this.OD002_NOM_REDUZIDO))} ,  {FieldThreatment((this.VIND_NULL11?.ToInt() == -1 ? null : this.OD002_COD_CBO))} ,  {FieldThreatment((this.VIND_NULL12?.ToInt() == -1 ? null : this.OD002_NOM_PRIMEIRO))} ,  {FieldThreatment((this.VIND_NULL13?.ToInt() == -1 ? null : this.OD002_NOM_ULTIMO))})";

            return query;
        }
        public string OD002_NUM_PESSOA { get; set; }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string OD002_DTH_NASCIMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD002_STA_SEXO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD002_IND_ESTADO_CIVIL { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD002_STA_PESSOA { get; set; }
        public string OD002_NOM_TRATAMENTO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD002_COD_UF { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD002_NUM_MUNICIPIO { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD002_NUM_INSC_SOCIAL { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD002_NUM_DV_INSC_SOCIAL { get; set; }
        public string VIND_NULL08 { get; set; }
        public string OD002_NUM_GRAU_INSTRUCAO { get; set; }
        public string VIND_NULL09 { get; set; }
        public string OD002_NOM_REDUZIDO { get; set; }
        public string VIND_NULL10 { get; set; }
        public string OD002_COD_CBO { get; set; }
        public string VIND_NULL11 { get; set; }
        public string OD002_NOM_PRIMEIRO { get; set; }
        public string VIND_NULL12 { get; set; }
        public string OD002_NOM_ULTIMO { get; set; }
        public string VIND_NULL13 { get; set; }

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